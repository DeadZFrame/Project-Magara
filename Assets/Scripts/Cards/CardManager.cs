using System;
using System.Collections.Generic;
using Localization;
using UnityEngine.UI;

namespace Cards
{
    public enum CardType
    {
        Lava, Water, H2O, Toxic, Hot, Cold, Night, Day,
        Rock, Grass, Tree, Building, Meat, Veg, Cat, Dog, Mom,
        Dad,
    }

    public static class CardManager
    {
        private static readonly Dictionary<Enum, CardHolder.Card> CardDict = new Dictionary<Enum, CardHolder.Card>();

        public static void AddCard(Enum type, CardHolder.Card card)
        {
            if(!CardDict.ContainsKey(type)) CardDict.Add(type, card);
        }

        public static CardHolder.Card GetCard(CardType cardType)
        {
            return !CardDict.ContainsKey(cardType) ? null : CardDict[cardType];
        }
    }
}