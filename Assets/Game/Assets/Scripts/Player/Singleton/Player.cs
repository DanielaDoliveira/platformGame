using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player.Singleton
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public static Rigidbody2D _Rigidbody2D;
        public static Animator Animator;
        public  static float Speed;
        public  static float Movement; 
        public static float JumpForce;
        public static bool IsJumping, DoubleJump;
        public static bool Is_Attacking;
      

        void Start()
        {
            _Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator =GetComponentInChildren<Animator>();
        }

       
    }

}