using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Collections;
using Platformer.Assets.Game.Scripts.Player.Enum;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    
    
    public class PlayerAttack: MonoBehaviour
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
      
        private float time_attack = 0.22f;

        public void Start()
        {
            Singleton.Player.Is_Attacking = false;
        }


        public void Execute()
        {
          
                Singleton.Player.Is_Attacking = true;
                PlayerAnimator.instance.Animate(PlayerEnum.attack);
                Collider2D _hit = Physics2D.OverlapCircle(point.position,radius);
                if (_hit != null)
                {
                    Debug.Log(_hit.name);
                }

                StartCoroutine(OnAttack());
            
          
        }

        IEnumerator OnAttack()
        {
            yield return new WaitForSeconds(time_attack);
            Singleton.Player.Is_Attacking = false;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(point.position,radius);
        }
    }
}