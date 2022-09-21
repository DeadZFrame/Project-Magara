using System.Collections;
using Cards;
using Environment;
using Localization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class OnClick : MonoBehaviour
    {
        private static UIManager UIManager => UIManager.Instance;

        private Animator LeftCardAnim => UIManager.cards.leftCard.GetComponent<Animator>();
        private Animator RightCardAnim => UIManager.cards.rightCard.GetComponent<Animator>();
        
        public void ENG()
        {
            Core.GameSettings.Language = Languages.English;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void TR()
        {
            Core.GameSettings.Language = Languages.Turkish;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LeftCard()
        {
            var rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: SFXManager.Instance.Play(SFXManager.SoundName.Pick1);
                    break;
                case 1: SFXManager.Instance.Play(SFXManager.SoundName.Pick2);
                    break;
                case 2: SFXManager.Instance.Play(SFXManager.SoundName.Pick3); break;
            }
            
            SFXManager.Instance.Play(SFXManager.SoundName.Silent);
            
            UIManager.cards.leftCard.GetComponent<Button>().interactable = false;
            UIManager.cards.rightCard.GetComponent<Button>().interactable = false;
            
            LeftCardAnim.SetTrigger(Select);
            RightCardAnim.SetTrigger(UnSelect);

            var card = CardManager.CardEnums[CardManager.Index];
            CardManager.NonUseCards.Add(card);
            EarthManager.Instance.AddEarthState(card);
            
            StartCoroutine(ChangeCard());
        }

        public void RightCard()
        {
            var rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: SFXManager.Instance.Play(SFXManager.SoundName.Pick1);
                    break;
                case 1: SFXManager.Instance.Play(SFXManager.SoundName.Pick2);
                    break;
                case 2: SFXManager.Instance.Play(SFXManager.SoundName.Pick3); break;
            }
            
            SFXManager.Instance.Play(SFXManager.SoundName.Silent);
            
            UIManager.cards.leftCard.GetComponent<Button>().interactable = false;
            UIManager.cards.rightCard.GetComponent<Button>().interactable = false;
            
            LeftCardAnim.SetTrigger(UnSelect);
            RightCardAnim.SetTrigger(Select);
            
            var card = CardManager.CardEnums[CardManager.Index + 1];
            CardManager.NonUseCards.Add(card);
            EarthManager.Instance.AddEarthState(card);
            
            StartCoroutine(ChangeCard());
        }

        private IEnumerator ChangeCard()
        {
            var time = 1.5f;
            while (time >= 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            CardManager.Index += 2;
            
            Debug.Log(CardManager.Index);
            
            if (CardManager.Index > 15)
            {
                UIManager.keepOn.SetActive(true);
                
                UIManager.cards.leftCard.SetActive(false);
                UIManager.cards.rightCard.SetActive(false);

                yield break;
            }
            
            CardHolder.Instance.SetCard(CardManager.CardEnums[CardManager.Index],
                CardManager.CardEnums[CardManager.Index + 1]);
            
            UIManager.cards.leftCard.GetComponent<Button>().interactable = true;
            UIManager.cards.rightCard.GetComponent<Button>().interactable = true;
        }

        private int _index = 0;
        private static readonly int Select = Animator.StringToHash("Select");
        private static readonly int UnSelect = Animator.StringToHash("UnSelect");

        private IEnumerator End()
        {
            while (UIManager.startScene.quote.GetComponent<TextMeshProUGUI>().alpha != 0)
            {
                yield return null;
            }

            UIManager.startScene.panel.SetActive(false);
            UIManager.startScene.quote.SetActive(false);
            
            EndingManager.Instance.Ending();
        }
        
        public void TakeScreenShot()
        {
            ScreenCapture.CaptureScreenshot(_index == 0 ? $"URMistSS.png" : $"URMistSS{_index}.png");
            _index += 1;
        }

        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void KeepOn()
        {
            SFXManager.Instance.Play(SFXManager.SoundName.KeepOn);
            SFXManager.Instance.Play(SFXManager.SoundName.Grinder);
            
            UIManager.keepOn.SetActive(false);
            
            UIManager.startScene.panel.SetActive(true);
            UIManager.startScene.quote.SetActive(true);
            StartCoroutine(End());
        }
        
        public void Exit(){
            Application.Quit();
        }
    }
}
