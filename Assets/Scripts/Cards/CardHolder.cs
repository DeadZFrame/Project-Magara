using System;
using System.Collections.Generic;
using Localization;
using UnityEngine;

namespace Cards
{
    [DefaultExecutionOrder(-4)]
    public class CardHolder : MonoBehaviour
    {
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
            foreach (var card in cards)
            {
                card.text = GetText(card.type);
                CardManager.AddCard(card.type, card);
            }
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