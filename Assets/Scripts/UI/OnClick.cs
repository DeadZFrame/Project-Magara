using System.Collections;
using Cards;
using Localization;
using UnityEngine;

namespace UI
{
    public class OnClick : MonoBehaviour
    {
        private static UIManager UIManager => UIManager.Instance;
        [SerializeField] private GameObject managers;

        private Animator LeftCardAnim => UIManager.cards.leftCard.GetComponent<Animator>();
        private Animator RightCardAnim => UIManager.cards.rightCard.GetComponent<Animator>();
        
        public void ENG()
        {
            Core.GameSettings.Language = Languages.English;
            managers.gameObject.SetActive(true);
            UIManager.startScene.quote.SetActive(false);
        }
        
        public void TR()
        {
            Core.GameSettings.Language = Languages.Turkish;
            managers.gameObject.SetActive(true);
            UIManager.startScene.quote.SetActive(true);
        }

        public void LeftCard()
        { 
            LeftCardAnim.SetTrigger(Select);
            RightCardAnim.SetTrigger(UnSelect);
            StartCoroutine(ChangeCard());
        }

        public void RightCard()
        {
            LeftCardAnim.SetTrigger(UnSelect);
            RightCardAnim.SetTrigger(Select);
            StartCoroutine(ChangeCard());
        }

        private IEnumerator ChangeCard()
        {
            while (!LeftCardAnim.GetNextAnimatorStateInfo(0).IsName("LeftCardDraw"))
            {
                yield return null;
            }
            
            CardHolder.Instance.SetCard(CardManager.CardEnums[CardManager.Index],
                CardManager.CardEnums[CardManager.Index]);
        }

        private int _index = 0;
        private static readonly int Select = Animator.StringToHash("Select");
        private static readonly int UnSelect = Animator.StringToHash("UnSelect");

        public void TakeScreenShot()
        {
            ScreenCapture.CaptureScreenshot(_index == 0 ? $"URMistScreenShot.png" : $"URMistScreenShot{_index}.png");
            _index += 1;
        }
    }
}
