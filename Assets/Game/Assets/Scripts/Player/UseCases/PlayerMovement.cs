
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Platformer.Assets.Game.Scripts.Player.Enum;

using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerMovement : MonoBehaviour
    {


      
        [Inject] private IPlayerAnimator _playerAnimator;

        public void Construct(IPlayerAnimator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        } 
    
       private void Start()
       {
        
           Singleton.Player.Speed = 5f;
        
       }

     

        public void Move()
        {
         Singleton.Player.Movement = Input.GetAxis("Horizontal");
         
         Singleton.Player._Rigidbody2D.velocity = 
             new Vector2(
                 Singleton.Player.Movement * Singleton.Player.Speed, 
                 Singleton.Player._Rigidbody2D.velocity.y
                 );
         
    
        }

        public void Execute()
        {
            Move();
            Flip();
        }

        public bool IsMoving()
        {
            if (Singleton.Player.Movement != 0)
                return true;

            return false;
        }

        public void CancelMovement()
        {
            Singleton.Player._Rigidbody2D.velocity = Vector2.zero;
            _playerAnimator.Animate(PlayerEnum.idle,Singleton.Player.Animator);
        }

        void Flip()
        {
           
            switch ( Singleton.Player.Movement)
            {
                case (> 0):
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        // PlayerAnimator.instance.Animate(PlayerEnum.walk);
                       _playerAnimator.Animate(PlayerEnum.walk,Singleton.Player.Animator);
                    }
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    
                    break;
                }
                case (< 0):
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        _playerAnimator.Animate(PlayerEnum.walk,Singleton.Player.Animator);
                       
                    }
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                }
                default:
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        _playerAnimator.Animate(PlayerEnum.idle,Singleton.Player.Animator);
                        
                    }
                    break;
                }
            }
        }
    }

}