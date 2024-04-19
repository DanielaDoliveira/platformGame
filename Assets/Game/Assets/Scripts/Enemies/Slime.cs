
using System;
using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    public class Slime: Enemy
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
        [SerializeField]private LayerMask layer;




        void Start()
        {
            base.Start();
            speed = -1.5f;
        }

        private void FixedUpdate()
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            OnCollision();
        }

         void OnCollision()
        {
            Collider2D _hit = Physics2D.OverlapCircle(point.position,radius,layer);
            if (_hit != null)
            {
              SlimeBehaviour();
            }
        }

         
        void SlimeBehaviour()
        {
            speed = -speed;
            SlimeFLip();
           
         
        }

        void SlimeFLip()
        {
            float rotation_y = transform.position.y;
            if (transform.eulerAngles.y == 0)
            {
                rotation_y = 180;
               
                
            }
            else if (transform.eulerAngles.y == 180)
            {
                rotation_y = 0;
              
            }
            transform.eulerAngles = new Vector3(0, rotation_y, 0);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(point.position,radius);
           
        }
    }
}