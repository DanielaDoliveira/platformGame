using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GetAttributes:MonoBehaviour
    {

        [Inject] private IPlayerLife _playerLife;

        public GetAttributes(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }
        public void Start()
        {
           var health= PlayerPrefs.GetInt("HEALTH");
           _playerLife.Health = health;
        }
    }
}