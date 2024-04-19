using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Collections;
using Game.Assets.Scripts.Enemies;
using Platformer.Assets.Game.Scripts.Player.Enum;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    
    
    public class PlayerAttack: MonoBehaviour
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
      
        private float time_attack = 0.22f;
        public LayerMask Enemy_Layer;
        public void Start()
        {
            Singleton.Player.Is_Attacking = false;
            
        }


        public void Execute()
        {
          
                Singleton.Player.Is_Attacking = true;
                PlayerAnimator.instance.Animate(PlayerEnum.attack);
                VerifyCollision();

                StartCoroutine(OnAttack());
            
          
        }

        private void VerifyCollision()
        {

            Collider2D _hit = Physics2D.OverlapCircle(point.position,radius,Enemy_Layer);
       
            if (_hit != null)
            {
                Debug.Log(_hit.name);
                _hit.GetComponent<Slime>().OnHit();
            }
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