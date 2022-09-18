using System;
using System.Collections.Generic;
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

        [Serializable]
        public class PartsByType
        {
            public CardType cardType;
            public List<Sprite> parts;
        }

        public List<PartsByType> partsByType;

        public void Ending()
        {
            foreach (var parts in partsByType)
            {
                foreach (var card in CardManager.NonUseCards)
                {
                    if (parts.cardType != card) continue;
                    
                    foreach (var part in parts.parts)
                    {
                        Instantiate(part, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
