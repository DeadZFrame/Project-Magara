using System;
using System.Collections.Generic;
using Cards;
using UnityEngine;

namespace Localization
{
    public enum Languages
    {
        English, Turkish
    }

    [DefaultExecutionOrder(-5)]
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager Instance { get; private set; }
        [Serializable]
        public class TextLanguage
        {
            public Languages language;
            
            [Serializable]
            public class Texts
            {
                public CardType textID;
                public string text;
            }

            public List<Texts> texts;
        }

        public List<TextLanguage> textLanguage;

        public readonly Dictionary<Enum, TextLanguage.Texts> EnglishCards = new Dictionary<Enum, TextLanguage.Texts>();
        public readonly Dictionary<Enum, TextLanguage.Texts> TurkishCards = new Dictionary<Enum, TextLanguage.Texts>();

        private void Awake()
        {
            Instance = this;
            
            foreach (var language in textLanguage)
            {
                foreach (var text in language.texts)
                {
                    switch (language.language)
                    {
                        case Languages.English:
                            EnglishCards.Add(text.textID, text);
                            break;
                        case Languages.Turkish:
                            TurkishCards.Add(text.textID, text);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            
            
        }
    }
}
