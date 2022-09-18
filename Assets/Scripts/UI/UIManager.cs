using System;
using System.Collections;
using Core;
using Localization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    [DefaultExecutionOrder(-5)]
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private Animator QuoteAnim => startScene.semiQuote.GetComponent<Animator>();
        private TextMeshProUGUI QuoteText => startScene.semiQuote.GetComponent<TextMeshProUGUI>();
        private Image PanelImage => startScene.panel.GetComponent<Image>();

        private void Awake()
        {
            Debug.Log(GameSettings.Language);
            Instance = this;

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                startScene.panel.SetActive(true);
                QuoteText.SetText(GetText(UIType.QuoteSemi));
                StartCoroutine(EndQuote());
                startScene.quote.GetComponent<TextMeshProUGUI>().SetText(GetText(UIType.Quote));
                keepOn.GetComponentInChildren<TextMeshProUGUI>().SetText(GetText(UIType.Keep));
                
                endtext.SetText(GetText(UIType.Endtext));
            }

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                play.SetText(GetText(UIType.Play));
                credits.SetText(GetText(UIType.Credits));
            }
            
            
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().buildIndex != 0)Time.timeScale = startScene.panel.activeInHierarchy ? 0 : 1;
        }

        private IEnumerator EndQuote()
        {
            while (QuoteText.alpha != 0)
            {
                yield return null;
            }
            startScene.semiQuote.SetActive(false);
            startScene.panel.SetActive(false);
        }

        [Serializable]
        public class Cards
        {
            public GameObject rightCard;
            public GameObject leftCard;
        }
        
        public Cards cards;
        public GameObject endPanel;

        public GameObject keepOn;
        public GameObject referance;
        public TextMeshProUGUI endtext;
        
        [Serializable]
        public class StartScene
        {
            public GameObject panel;
            public GameObject languageSelect;
            public GameObject semiQuote;
            public GameObject quote;
        }

        public TextMeshProUGUI play;
        public TextMeshProUGUI credits;

        public StartScene startScene;

        public Canvas canvas;
        
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
