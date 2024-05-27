
using UnityEngine;
using System.Collections;
using Game.Assets.Scripts.Enemies;
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Platformer.Assets.Game.Scripts.Player.Enum;
using UnityEngine.Events;
using Zenject;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    
    
    public class PlayerAttack: MonoBehaviour
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
        
        private float time_attack = 0.22f;
        public LayerMask Enemy_Layer;
        

        [Inject] private IPlayerAnimator _playerAnimator;

        public void Construct(IPlayerAnimator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }
        
        
        public void Start()
        {
            Singleton.Player.Is_Attacking = false;
            Enemy_Layer = LayerMask.GetMask("ENEMY", "SLIME", "GOBLIN");

        }


        public void Execute()
        {
          
                Singleton.Player.Is_Attacking = true;
                // PlayerAnimator.instance.Animate(PlayerEnum.attack);
                _playerAnimator.Animate(PlayerEnum.attack,Singleton.Player.Animator);
                PlayerAudio.instance.PlaySfx(PlayerAudio.instance.HitFx);
                VerifyCollision();

                StartCoroutine(OnAttack());
            
          
        }
    
        public void VerifyCollision()
        {

            Collider2D hit = Physics2D.OverlapCircle(point.position,radius,Enemy_Layer);
          
       
            if (hit != null)
            {
                
                switch (hit.tag)
                {
                    case "Slime":
                        hit.GetComponent<SlimeLife>().OnHit();
                        break;
                    case "Goblin":
                        hit.GetComponent<GoblinLife>().OnHit();
                        break;
                } 
                
            }
         

        }

       public IEnumerator OnAttack()
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