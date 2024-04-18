using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Collections;
using Platformer.Assets.Game.Scripts.Player.Enum;

namespace Platformer.Assets.Game.Scripts.Player
{
    
    
    public class PlayerAttack: MonoBehaviour
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
        private bool is_attacking;
        private float time_attack = 0.22f;


        public bool GetAttacking()
        {
            return is_attacking;
        }
        public void Update()
        {
           Attack();
        }

        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                is_attacking = true;
                PlayerAnimator.instance.Animate(PlayerEnum.attack);
                Collider2D _hit = Physics2D.OverlapCircle(point.position,radius);
                if (_hit != null)
                {
                    Debug.Log(_hit.name);
                }

                StartCoroutine(OnAttack());
            }
          
        }

        IEnumerator OnAttack()
        {
            yield return new WaitForSeconds(time_attack);
            is_attacking = false;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(point.position,radius);
        }
    }
}