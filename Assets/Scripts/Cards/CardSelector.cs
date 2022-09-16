using System;
using Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CardSelector : MonoBehaviour
    {
        private TextMeshProUGUI TextMeshPro => gameObject.GetComponentInChildren<TextMeshProUGUI>();
        private Image Image => gameObject.GetComponentInChildren<Image>();

        private LocalizationManager LocalizationManager => LocalizationManager.Instance;

        [SerializeField] private CardType cardType;
        private void Awake()
        {
            var card = CardManager.GetCard(cardType);
            Image.sprite = card.sprite;
            TextMeshPro.SetText(card.text);
        }
    }
}
