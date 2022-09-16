using Localization;
using UnityEngine;

namespace UI
{
    public class OnClick : MonoBehaviour
    {
        private static UIManager UIManager => UIManager.Instance;
        
        public void ENG()
        {
            Core.GameSettings.Language = Languages.English;
            UIManager.panel.SetActive(false);
        }
        
        public void TR()
        {
            UIManager.panel.SetActive(false);
            Core.GameSettings.Language = Languages.Turkish;
        }
    }
}
