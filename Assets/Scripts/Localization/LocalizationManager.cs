using System;
using System.Collections.Generic;
using Cards;
using Core;
using UnityEngine;

namespace Localization
{
    public enum Languages
    {
        English, Turkish
    }

    public enum UIType
    {
        Quote, QuoteSemi, Play, Credits, Keep, Endtext,
    }

    [DefaultExecutionOrder(-6)]
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
            
            [Serializable]
            public class UITexts
            {
                public UIType uIType;
                public string uIText;
            }

            public List<UITexts> uTexts;
        }

        public List<TextLanguage> textLanguage;

        public readonly Dictionary<Enum, TextLanguage.Texts> EnglishCards = new Dictionary<Enum, TextLanguage.Texts>();
        public readonly Dictionary<Enum, TextLanguage.Texts> TurkishCards = new Dictionary<Enum, TextLanguage.Texts>();

        public readonly Dictionary<Enum, TextLanguage.UITexts> EnglishTexts =
            new Dictionary<Enum, TextLanguage.UITexts>();
        public readonly Dictionary<Enum, TextLanguage.UITexts> TurkishTexts =
            new Dictionary<Enum, TextLanguage.UITexts>();

        private void Awake()
        {
            Instance = this;
            
            SFXManager.Instance.Play(SFXManager.SoundName.GameMusic);

            foreach (var language in textLanguage)
            {
                foreach (var text in language.texts)
                {
                    switch (language.language)
                    {
                        case Languages.English:
                            EnglishCards.Add(text.textID, text);
                            CardManager.CardEnums.Add(text.textID);
                            break;
                        case Languages.Turkish:
                            TurkishCards.Add(text.textID, text);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                foreach (var text in language.uTexts)
                {
                    switch (language.language)
                    {
                        case Languages.English:
                            EnglishTexts.Add(text.uIType, text);
                            break;
                        case Languages.Turkish:
                            TurkishTexts.Add(text.uIType, text);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                
                
            }
        }
    }
}
