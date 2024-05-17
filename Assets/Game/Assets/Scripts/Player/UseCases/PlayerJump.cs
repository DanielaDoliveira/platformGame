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


        public Transform point;
        public float radius = 0.22f;
        private LayerMask layer;
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
            layer = LayerMask.GetMask("GROUND","STONE");

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

      
        private void Update()
        {
            OnHitGround();
        }

        private void OnHitGround()
        {
            Collider2D hit = Physics2D.OverlapCircle(point.position, radius,layer);
            if (hit != null)
            {
                Debug.Log(layer);
                Singleton.Player.IsJumping = false;
            }
            else
            {
                Singleton.Player.IsJumping = true;
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(point.position,radius);
            Gizmos.color = Color.blue;
        }
    }
}