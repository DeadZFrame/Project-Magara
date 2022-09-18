using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Data;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    [DefaultExecutionOrder(-3)]
    public class EarthManager : MonoBehaviour
    {
        public static EarthManager Instance;
        [SerializeField] private EnvData envData;

        public GameObject FirstEarth => envData.firstEarth;
        public GameObject RockyEarth => envData.rockyEarth;
        public GameObject GreenEarth => envData.greenEarth;
        
        [SerializeField] private GameObject skyBox;
        [SerializeField] private GameObject sun;
        [SerializeField] private GameObject atmosphere;

        private Material FirstEarthMaterial
        {
            get => FirstEarth.GetComponent<Renderer>().sharedMaterial;
            set => throw new NotImplementedException();
        }

        private Material RockyEarthMaterial => RockyEarth.GetComponent<Renderer>().sharedMaterials[0];
        private Material GreenEarthMaterial => GreenEarth.GetComponent<Renderer>().sharedMaterials[0];

        private List<CardType> _cardTypes = new List<CardType>();

        private void Awake()
        {
            Instance = this;

            Instantiate(FirstEarth, transform.position, quaternion.identity);
            FirstEarthMaterial.color = new Color(0.7f, 0.89f, 1f);
        }

        public void AddEarthState(CardType cardType)
        {
            Debug.Log(cardType);
            
            switch (cardType)
            {
                case CardType.Lava:
                    FirstEarth.GetComponent<Renderer>().sharedMaterial.color = new Color(1f, 0.27f, 0f);
                    break;
                case CardType.Water:
                    FirstEarth.GetComponent<Renderer>().sharedMaterial.color = new Color(0f, 0.87f, 1f);
                    break;
                case CardType.H2O:
                    atmosphere.SetActive(true);
                    atmosphere.GetComponent<Image>().color = new Color(0f, 0.69f, 1f);
                    break;
                case CardType.Toxic:
                    atmosphere.SetActive(true);
                    atmosphere.GetComponent<Image>().color = Color.green;
                    break;
                case CardType.Hot:
                    GreenEarthMaterial.EnableKeyword("_EMISSION");
                    GreenEarthMaterial.SetColor("_EmissionColor", Color.red);
                    RockyEarthMaterial.EnableKeyword("_EMISSION");
                    RockyEarthMaterial.SetColor("_EmissionColor", Color.red);
                    break;
                case CardType.Cold:
                    GreenEarthMaterial.EnableKeyword("_EMISSION");
                    GreenEarthMaterial.SetColor("_EmissionColor", Color.blue);
                    RockyEarthMaterial.EnableKeyword("_EMISSION");
                    RockyEarthMaterial.SetColor("_EmissionColor", Color.blue);
                    break;
                case CardType.Night:
                    sun.SetActive(true);
                    var color = new Color(0.33f, 0.33f, 0.33f);
                    StartCoroutine(DayNight(color));
                    var mat = sun.GetComponent<Renderer>().sharedMaterial;
                    mat.SetColor("_EmissionColor", Color.cyan * 3);
                    var l = sun.GetComponentInChildren<Light>();
                    l.intensity = 1;
                    l.colorTemperature = 7000;
                    break;
                case CardType.Day:
                    var color2 = Color.white;
                    StartCoroutine(DayNight(color2));
                    sun.SetActive(true);
                    sun.GetComponent<Renderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1f, 0.78f, 0f) * 6);
                    break;
                case CardType.Rock:
                    StartCoroutine(ReduceEarthAlpha(cardType));
                    break;
                case CardType.Grass:
                    StartCoroutine(ReduceEarthAlpha(cardType));
                    break;
                case CardType.Tree:
                    break;
                case CardType.Building:
                    break;
                case CardType.Cat:
                    break;
                case CardType.Dog:
                    break;
                case CardType.Mom:
                    break;
                case CardType.Dad:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
            }
        }

        [SerializeField] private Material transparentMat;

        private IEnumerator ReduceEarthAlpha(CardType cardType)
        {
            var material = FirstEarthMaterial;
            material = transparentMat;
            
            Instantiate(cardType == CardType.Rock ? RockyEarth : GreenEarth, transform.position, quaternion.identity);
            
            while (material.color.a != 0)
            {
                material.color = new Color(material.color.r, material.color.g, material.color.b, Mathf.Lerp(material.color.a, 0, 0.1f));
                //RockyEarthMaterial.color = new Color(RockyEarthMaterial.color.r, RockyEarthMaterial.color.g, RockyEarthMaterial.color.b, Mathf.Lerp(RockyEarthMaterial.color.a, 255, 0.1f));
                yield return null;
            }
            
            FirstEarth.SetActive(false);
        }

        private IEnumerator DayNight(Color color)
        {
            var skyColor = skyBox.GetComponent<Image>().color;
            while (skyColor != color)
            {
                skyColor = Color.Lerp(skyColor, color, 0.1f);
                yield return null;
            }
        }
    }
}
