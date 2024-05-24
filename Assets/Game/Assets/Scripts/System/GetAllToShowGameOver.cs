using System;
using TMPro;
using UnityEngine;

namespace Game.Assets.Scripts
{
    public class GetAllToShowGameOver: MonoBehaviour
    {
        public TextMeshProUGUI CoinsText;
        private void Start()
        {
            CoinsText = GetComponent<TextMeshProUGUI>();
            CoinsText.text = string.Format("x {0}", PlayerPrefs.GetInt("COINS").ToString());
        }
    }
}