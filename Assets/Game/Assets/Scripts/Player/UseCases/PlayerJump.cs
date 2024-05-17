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

    
    

       public void Execute()
        {
            
                if (!Singleton.Player.IsJumping)
                {
                   
                    _playerAnimator.Animate(PlayerEnum.jump,Singleton.Player.Animator);
                    PlayerAudio.instance.PlaySfx(PlayerAudio.instance.JumpFx);
                    Singleton.Player._Rigidbody2D.AddForce(Vector2.up * Singleton.Player.JumpForce,ForceMode2D.Impulse);
                    Singleton.Player.IsJumping = true;
                    Singleton.Player.DoubleJump = true;
                }
                else if ( Singleton.Player.DoubleJump)
                {
                  
                    _playerAnimator.Animate(PlayerEnum.jump,Singleton.Player.Animator);
                    PlayerAudio.instance.PlaySfx(PlayerAudio.instance.JumpFx);
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