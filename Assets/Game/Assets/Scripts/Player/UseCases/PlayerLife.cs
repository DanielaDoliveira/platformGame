using System;
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Platformer.Assets.Game.Scripts.Player.Singleton;
using Platformer.Assets.Game.Scripts.Player.UseCases;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Player.UseCases
{
    public class PlayerLife: MonoBehaviour
    {
        [Inject] private IPlayerLife _playerLife;
        public int Health = 3;
        public bool Recovery;
        public float RecoveryCount = 2f;
        public void Constructor(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }

        public void OnHit()
        {
            StartCoroutine(_playerLife.HitTimeCounter(PlayerAnimator.instance));
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("ENEMY")|| other.gameObject.CompareTag("Slime")|| other.gameObject.CompareTag("Goblin"))
            {
          
                OnHit();
            }
        }
    }
}