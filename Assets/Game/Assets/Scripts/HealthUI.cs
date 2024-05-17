using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts
{
    public class HealthUI: MonoBehaviour
    {
        public int Health;
        public int HeartsCount;
        public List<Image> Hearts;
        public Sprite HeartFilled;
        public Sprite HeartEmpty;


        private void Update()
        {
          DrawHearts();
        }

        public void DrawHearts()
        {
            for (int i = 0; i < Hearts.Count; i++)
            {
                if (i < Health)
                    Hearts[i].sprite = HeartFilled;
                else
                    Hearts[i].sprite = HeartEmpty;
                
                if (i < HeartsCount)
                    Hearts[i].enabled = true;
                else
                    Hearts[i].enabled = false;
            }
        }
    }
}