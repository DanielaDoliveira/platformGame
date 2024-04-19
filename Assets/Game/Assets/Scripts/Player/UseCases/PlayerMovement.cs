using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Platformer.Assets.Game.Scripts.Player.Singleton;
namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerMovement : MonoBehaviour
    {
    
    
      
    
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

        void Flip()
        {
           
            switch ( Singleton.Player.Movement)
            {
                case (> 0):
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.walk);
                       
                    }
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    
                    break;
                }
                case (< 0):
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.walk);
                       
                    }
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                }
                default:
                {
                    if (!Singleton.Player.IsJumping && !Singleton.Player.Is_Attacking)
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.idle);
                        
                    }
                    break;
                }
            }
        }
    }

}