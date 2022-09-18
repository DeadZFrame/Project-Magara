using System;
using System.Collections.Generic;
using Environment;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class EndingManager : MonoBehaviour
    {
        public static EndingManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField] private Transform referance;

        [Serializable]
        public class PartsByType
        {
            public CardType cardType;
            public List<Sprite> parts;
        }

        public List<PartsByType> partsByType;

        [SerializeField] private Image image;

        private int _index;  
        public void Ending()
        {
            UIManager.Instance.endPanel.SetActive(true);

            while (_index < 4)
            {
                foreach (var parts in partsByType)
                {
                    foreach (var card in CardManager.NonUseCards)
                    {
                        if (parts.cardType != card) continue;
                    
                        foreach (var part in parts.parts)
                        {
                            var img = Instantiate(this.image, referance.transform.parent, true);
                            img.GetComponent<RectTransform>().anchoredPosition =
                                referance.GetComponent<RectTransform>().anchoredPosition;
                            img.sprite = part;
                            img.AddComponent<Patrol>();
                        }
                    }
                }

                _index++;
            }
            
        }
    }
}
