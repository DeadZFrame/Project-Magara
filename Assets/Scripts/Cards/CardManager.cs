using System;
using System.Collections.Generic;

namespace Cards
{
    public enum CardType
    {
        Lava, Water, H2O, Toxic, Hot, Cold, Night, Day,
        Rock, Grass, Tree, Building, Cat, Dog, Mom,
        Dad,
    }

    public static class CardManager
    {
        public static int Index;
        
        public static readonly List<CardType> CardEnums = new List<CardType>()
        {
            CardType.Lava, CardType.Water, CardType.H2O, CardType.Toxic, CardType.Hot, CardType.Cold, CardType.Night,
            CardType.Day, CardType.Rock, CardType.Grass, CardType.Tree, CardType.Building,
            CardType.Cat, CardType.Dog, CardType.Mom, CardType.Dad,
        };
        
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