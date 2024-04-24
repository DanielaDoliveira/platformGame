using System;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerLife:MonoBehaviour
    {
        public int Health = 3;
        
        public void OnHit()
        {
            PlayerAnimator.instance.Hit();
            PlayerDamage(1);
        }

        public void PlayerDamage(int _health)
        {
            Health -= _health;
            if (Health <= 0)
            {
                PlayerAnimator.instance.Dead();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 6)
            {
                OnHit();
            }
        }
    }
}