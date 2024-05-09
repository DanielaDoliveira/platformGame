using System;
using System.Collections;
using System.Collections.Generic;
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerJump : MonoBehaviour
    {



        [Inject] private IPlayerAnimator _playerAnimator;

        public void Construct(IPlayerAnimator playerAnimator)
        {
            _playerAnimator = playerAnimator;
        }
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
                    // PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    _playerAnimator.Animate(PlayerEnum.jump,Singleton.Player.Animator);
                    Singleton.Player._Rigidbody2D.AddForce(Vector2.up * Singleton.Player.JumpForce,ForceMode2D.Impulse);
                    Singleton.Player.IsJumping = true;
                    Singleton.Player.DoubleJump = true;
                }
                else if ( Singleton.Player.DoubleJump)
                {
                    // PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    _playerAnimator.Animate(PlayerEnum.jump,Singleton.Player.Animator);
                    Singleton.Player._Rigidbody2D.AddForce(Vector2.up * Singleton.Player.JumpForce,ForceMode2D.Impulse);
                    Singleton.Player.DoubleJump = false;
                }
               
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 3 || other.gameObject.layer == 8)
            {
                Singleton.Player.IsJumping = false;
            }
        }
    }
}
