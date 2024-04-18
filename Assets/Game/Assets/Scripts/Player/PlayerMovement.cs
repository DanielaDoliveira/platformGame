using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Platformer.Assets.Game.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
    
       [SerializeField] private float _speed;
       private float _movement;
       private PlayerJump _playerJump;

       private void Start()
       {
           _playerJump = GetComponent<PlayerJump>();
       }

       private void FixedUpdate()
        {
            Move();
            Flip();
        }

        void Move()
        {
         _movement = Input.GetAxis("Horizontal");
         Player._Rigidbody2D.velocity = new Vector2(_movement * _speed,  Player._Rigidbody2D.velocity.y);
         
    
        }

        void Flip()
        {
           
            switch (_movement)
            {
                case (> 0):
                {
                    if (!_playerJump.GetJumping())
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.walk);
                       
                    }
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    
                    break;
                }
                case (< 0):
                {
                    if (!_playerJump.GetJumping())
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.walk);
                       
                    }
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                }
                default:
                {
                    if (!_playerJump.GetJumping())
                    {
                        PlayerAnimator.instance.Animate(PlayerEnum.idle);
                        
                    }
                    break;
                }
            }
        }
    }

}