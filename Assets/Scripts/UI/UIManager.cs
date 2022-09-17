using System;
using System.Collections;
using Localization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private Animator QuoteAnim => startScene.quote.GetComponent<Animator>();
        private TextMeshProUGUI QuoteText => startScene.quote.GetComponent<TextMeshProUGUI>();
        private Image PanelImage => startScene.panel.GetComponent<Image>();

        private void Awake()
        {
            Instance = this;

            QuoteText.SetText(GetText(UIType.Quote));
        }

        private void Update()
        {
            Time.timeScale = startScene.panel.activeInHierarchy ? 1 : 0;
        }

        private IEnumerator EndQuote()
        {
            while (QuoteText.alpha != 0)
            {
                yield return null;
            }
            startScene.quote.SetActive(false);
            startScene.panel.SetActive(false);
        }

        [Serializable]
        public class Cards
        {
            public GameObject rightCard;
            public GameObject leftCard;
        }
        
        public Cards cards;
        
        [Serializable]
        public class StartScene
        {
            public GameObject panel;
            public GameObject languageSelect;
            public GameObject quote;
        }

        public StartScene startScene;
        
        private static string GetText(UIType uıType)
        {
            return Core.GameSettings.Language switch
            {
                Languages.English => LocalizationManager.Instance.EnglishTexts[uıType].uIText,
                Languages.Turkish => LocalizationManager.Instance.TurkishTexts[uıType].uIText,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
    
    
}
