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
        [SerializeField] private GameObject skyBox;
        [SerializeField] private GameObject sun;

        private Material FirstEarthMaterial
        {
            get => FirstEarth.GetComponent<Material>();
            set => throw new NotImplementedException();
        }

        private Material RockyEarthMaterial => RockyEarth.GetComponent<Material>();

        private List<CardType> _cardTypes = new List<CardType>();

        private void Awake()
        {
            Instance = this;

            Instantiate(FirstEarth, transform.position, quaternion.identity);
        }

        public void AddEarthState(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Lava:
                    FirstEarth.GetComponent<Material>().color = new Color(1f, 0.27f, 0f);
                    break;
                case CardType.Water:
                    FirstEarth.GetComponent<Material>().color = new Color(0f, 0.87f, 1f);
                    break;
                case CardType.H2O:
                    
                    break;
                case CardType.Toxic:
                    break;
                case CardType.Hot:
                    
                    break;
                case CardType.Cold:
                    break;
                case CardType.Night:
                    skyBox.GetComponent<Image>().color = new Color(0.49f, 0.49f, 0.49f);
                    var mat = sun.GetComponent<Renderer>().material;
                    mat.SetColor("_EmissionColor", Color.cyan);
                    var l = sun.GetComponentInChildren<Light>();
                    l.intensity = 1;
                    l.colorTemperature = 7000;
                    break;
                case CardType.Day:
                    skyBox.GetComponent<Image>().color = Color.white;
                    sun.SetActive(true);
                    break;
                case CardType.Rock:
                    StartCoroutine(ReduceEarthAlpha());
                    sun.SetActive(true);
                    break;
                case CardType.Grass:
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

        private IEnumerator ReduceEarthAlpha()
        {
            FirstEarthMaterial = transparentMat;
            Instantiate(RockyEarth, transform.position, quaternion.identity);
            while (transparentMat.color.a != 0)
            {
                transparentMat.color = new Color(transparentMat.color.r, transparentMat.color.g, transparentMat.color.b, Mathf.Lerp(transparentMat.color.a, 0, 0.1f));
                RockyEarthMaterial.color = new Color(RockyEarthMaterial.color.r, RockyEarthMaterial.color.g, RockyEarthMaterial.color.b, Mathf.Lerp(RockyEarthMaterial.color.a, 255, 0.1f))
                yield return null;
            }
            
            FirstEarth.SetActive(false);
        }
    }
}
