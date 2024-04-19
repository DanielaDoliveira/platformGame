using System;

using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    
    
    public class Enemy: MonoBehaviour
    {
        protected  Rigidbody2D rb2d;
        protected float speed;
        public static LayerMask EnemyLayer;

        public void Start()
        {
         
            rb2d = GetComponent<Rigidbody2D>();
        }
        
    }
}