using System;
using System.Collections.Generic;
using Localization;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    [DefaultExecutionOrder(-4)]
    public class CardHolder : MonoBehaviour
    {
        public static CardHolder Instance;
        
        [Serializable]
        public class Card
        {
            public CardType type;
            public Sprite sprite;
            public string text;
        }

        public List<Card> cards;

        private void Awake()
        {
            Instance = this;
            
            foreach (var card in cards)
            {
                card.text = GetText(card.type);
                CardManager.AddCard(card.type, card);
            }
        }

        private Image LeftImage => UIManager.Instance.cards.leftCard.transform.GetChild(0).GetComponent<Image>();
        private TextMeshProUGUI LeftText => UIManager.Instance.cards.leftCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        private Image RightImage => UIManager.Instance.cards.rightCard.transform.GetChild(0).GetComponent<Image>();
        private TextMeshProUGUI RightText => UIManager.Instance.cards.rightCard.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        private void Start()
        {
            CardManager.Index = 0;
            SetCard(CardManager.CardEnums[CardManager.Index], CardManager.CardEnums[CardManager.Index + 1]);
        }

        public void SetCard(CardType leftCardType, CardType rightCardType)
        {
            LeftImage.sprite = CardManager.GetCard(leftCardType).sprite;
            LeftText.SetText(GetText(leftCardType));
            
            RightImage.sprite = CardManager.GetCard(rightCardType).sprite;
            RightText.SetText(GetText(rightCardType));
        }

        private static string GetText(CardType cardType)
        {
            return Core.GameSettings.Language switch
            {
                Languages.English => LocalizationManager.Instance.EnglishCards[cardType].text,
                Languages.Turkish => LocalizationManager.Instance.TurkishCards[cardType].text,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}