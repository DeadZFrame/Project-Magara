using System.Collections;
using Cards;
using Environment;
using Localization;
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
            UIManager.startScene.quote.SetActive(false);
        }
        
        public void TR()
        {
            Core.GameSettings.Language = Languages.Turkish;
            UIManager.startScene.quote.SetActive(true);
        }

        public void LeftCard()
        {
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
                EndingManager.Instance.Ending();
                
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

        public void TakeScreenShot()
        {
            ScreenCapture.CaptureScreenshot(_index == 0 ? $"URMistSS.png" : $"URMistSS{_index}.png");
            _index += 1;
        }

        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
