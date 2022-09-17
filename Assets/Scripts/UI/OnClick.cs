using Localization;
using UnityEngine;

namespace UI
{
    public class OnClick : MonoBehaviour
    {
        private static UIManager UIManager => UIManager.Instance;
        private GameObject Managers => UIManager.gameObject;
        
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
            
        }

        public void RightCard()
        {
            
        }
    }
}
