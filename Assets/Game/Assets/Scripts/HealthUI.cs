using System;
using System.Collections.Generic;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Player.UseCases;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Assets.Scripts
{
    public class HealthUI: MonoBehaviour
    {
        public int Health = 3;
        public int HeartsCount;
        public List<Image> Hearts;
        public Sprite HeartFilled;
        public Sprite HeartEmpty;
        public static HealthUI instance;
        [Inject] private IPlayerLife _playerLife;

        public HealthUI(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }

       

        private void Start()
        {
         //   PlayerPrefs.SetInt("HEALTH", 3);
        }

        private void Update()
        {
            if (!PlayerLife.SceneLoaded)
            {
              
                HeartsCount = _playerLife.Health;
                PlayerLife.SceneLoaded = true;
            }
          DrawHearts();
        
        }

        public void DrawHearts()
        {
            
            var health= PlayerPrefs.GetInt("HEALTH");
            if (health > 0 )
            {
                Health = health;
                HeartsCount = 3;
            }
          else
            {
                Health = _playerLife.Health;
                HeartsCount = Health;
               
            }
            
            
         
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