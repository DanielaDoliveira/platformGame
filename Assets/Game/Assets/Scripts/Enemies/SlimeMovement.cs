
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace Game.Assets.Scripts.Enemies
{
    public class SlimeMovement: Enemy
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
        [SerializeField]private LayerMask layer;

        private new void Start()
        {
            base.Start();
            Speed = -1.5f;
         
            EnemyLayer = LayerMask.NameToLayer("ENEMY");
           

        }

        private void FixedUpdate()
        {
            Movement();
        }


        public void Movement()
        {
            Rb2d.velocity = new Vector2(Speed, Rb2d.velocity.y);
            OnCollision();
        }

         void OnCollision()
        {
            Collider2D hit = Physics2D.OverlapCircle(point.position,radius,layer);
            if (hit != null)
            {
              SlimeBehaviour();
            }
        }

         
        void SlimeBehaviour()
        {
            Speed = -Speed;
            SlimeFlip();
           
         
        }

        void SlimeFlip()
        {
            float rotationY = transform.position.y;
           
            float angle = transform.eulerAngles.y;
     
            if (angle == 0)
            {
                rotationY = 180;
               
                
            }
            else if (angle == 180)
            {
                rotationY = 0;
              
            }
            transform.eulerAngles = new Vector3(0, rotationY, 0);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(point.position,radius);
           
        }


        
    }
}