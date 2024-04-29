using System;

using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    
    
    public class Enemy: MonoBehaviour
    {
        protected  Rigidbody2D Rb2d;
        protected float Speed;
        public static LayerMask EnemyLayer;
        protected int Health;
        protected EnemyAnimator Enemy_animator;
        public void Start()
        {
         
            Rb2d = GetComponent<Rigidbody2D>();
            Enemy_animator = GetComponent<EnemyAnimator>();
        }
        
    }
}