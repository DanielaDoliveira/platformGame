using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player
{
    public class PlayerJump : MonoBehaviour
    {
       [SerializeField] private float jump_force;
       private bool is_jumping, double_jump;

       public bool GetJumping()
       {
           return is_jumping;
       }
     
        void Start()
        {
            is_jumping = false;
            double_jump = false;
           
        }

        // Update is called once per frame
        void Update()
        {
            Jump();
        }

        void Jump()
        {
            if(Input.GetButtonDown("Jump"))
            {
                if (!is_jumping)
                {
                    PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    Player._Rigidbody2D.AddForce(Vector2.up * jump_force,ForceMode2D.Impulse);
                    is_jumping = true;
                    double_jump = true;
                }
                else if (double_jump)
                {
                    PlayerAnimator.instance.Animate(PlayerEnum.jump);
                    Player._Rigidbody2D.AddForce(Vector2.up * jump_force,ForceMode2D.Impulse);
                    double_jump = false;
                }
               
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 3)
            {
                is_jumping = false;
            }
        }
    }
}
