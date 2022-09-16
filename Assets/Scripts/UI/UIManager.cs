using System;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        [Serializable]
        public class Cards
        {
            public GameObject rightCard;
            public GameObject leftCard;
        }

        public GameObject panel;

        public Cards cards;
    }
}
