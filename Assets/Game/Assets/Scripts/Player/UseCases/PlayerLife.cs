using System;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerLife:MonoBehaviour
    {
        public int Health = 3;
        private bool _recovery;
        float _recoveryCount = 2f;
        public void OnHit()
        {
         
           _recoveryCount += Time.deltaTime;
           if (_recoveryCount >= 2f)
           {
               PlayerAnimator.instance.Hit();
               PlayerDamage(1);
               _recoveryCount = 0;
           }
           
        }

        public void PlayerDamage(int _health)
        {
            Health -= _health;
            if (Health <= 0 && !_recovery)
            {
                _recovery = true;
                PlayerAnimator.instance.Dead();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("ENEMY"))
            {
                Debug.Log("COLIDIU");
                OnHit();
            }
        }
    }
}