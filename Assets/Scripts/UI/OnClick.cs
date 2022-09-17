using Localization;
using UnityEngine;

namespace UI
{
    public class OnClick : MonoBehaviour
    {
        private static UIManager UIManager => UIManager.Instance;
        [SerializeField] private GameObject managers;
        
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
            
        }

        public void RightCard()
        {
            
        }

        private int _index = 0;
        public void TakeScreenShot()
        {
            ScreenCapture.CaptureScreenshot(_index == 0 ? $"URMistScreenShot.png" : $"URMistScreenShot{_index}.png");
            _index += 1;
        }
    }
}
