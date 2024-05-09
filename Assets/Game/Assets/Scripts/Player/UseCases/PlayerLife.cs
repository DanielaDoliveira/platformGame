using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;

using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Player.UseCases
{
    public class PlayerLife : MonoBehaviour
    {
     
        private LayerMask layer;
        [SerializeField] private float radius;
        [Inject] private IPlayerLife _playerLife;
        [Inject] private IPlayerAnimator _playerAnimator;


        public void Constructor(IPlayerLife playerLife, IPlayerAnimator playerAnimator)
        {
            _playerLife = playerLife;
            _playerAnimator = playerAnimator;
        }

        public void Start()
        {
            radius = 0.43f;
            layer = LayerMask.GetMask("ENEMY", "SLIME", "GOBLIN");
        }

     

        public void OnHit()
        {
            StartCoroutine(_playerLife.HitTimeCounter(_playerAnimator, GetComponentInChildren<Animator>()));
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            var tags = 
                        other.gameObject.CompareTag("ENEMY")
                       || 
                       other.gameObject.CompareTag("Slime") 
                       ||
                       other.gameObject.CompareTag("Goblin"); 
            
            if (tags)
                OnHit();
        
        }

       
    }
}

