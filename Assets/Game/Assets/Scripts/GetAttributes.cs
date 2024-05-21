using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GetAttributes:MonoBehaviour
    {

        [Inject] private IPlayerLife _playerLife;
        public HealthUI _HealthUI;
        public GetAttributes(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }
        public void Start()
        {
           var health= PlayerPrefs.GetInt("HEALTH");
           if (health <= 0)
           {
               health = _playerLife.Health;
               _HealthUI.HeartsCount = _playerLife.Health;
           }
           _playerLife.Health = health;
           _HealthUI.HeartsCount = health;
        }
    }
}