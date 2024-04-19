using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerJump : MonoBehaviour
    {
    
     

       
        void Start()
        {
            Singleton.Player.IsJumping = false;
            Singleton.Player.DoubleJump = false;
            Singleton.Player.JumpForce = 10;

        }

        // Update is called once per frame
    

       public void Execute()
        {
            
                if (!Singleton.Player.IsJumping)
                {
                    PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    Singleton.Player._Rigidbody2D.AddForce(Vector2.up * Singleton.Player.JumpForce,ForceMode2D.Impulse);
                    Singleton.Player.IsJumping = true;
                    Singleton.Player.DoubleJump = true;
                }
                else if ( Singleton.Player.DoubleJump)
                {
                    PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    Singleton.Player._Rigidbody2D.AddForce(Vector2.up * Singleton.Player.JumpForce,ForceMode2D.Impulse);
                    Singleton.Player.DoubleJump = false;
                }
               
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 3)
            {
                Singleton.Player.IsJumping = false;
            }
        }
    }
}
