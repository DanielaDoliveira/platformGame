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
        public int Health;
        public int HeartsCount;
        public List<Image> Hearts;
        public Sprite HeartFilled;
        public Sprite HeartEmpty;

        [Inject] private IPlayerLife _playerLife;

        public HealthUI(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }

        private void Start()
        {
            Health = _playerLife.Health;
            HeartsCount = _playerLife.Health;
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
            Health = _playerLife.Health;
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