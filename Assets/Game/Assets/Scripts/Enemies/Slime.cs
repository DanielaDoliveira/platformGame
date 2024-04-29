
using System;
using System.Collections;
using System.Collections.Generic;
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
            Speed = -1.5f;
            Health = 3;
            EnemyLayer = LayerMask.NameToLayer("ENEMY");
           

        }

        private void FixedUpdate()
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
            //condition ? consequent : alternative
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
        IEnumerator TimeToDestroy()
        {
            Speed = 0;
            Enemy_animator.Death();
            yield return new WaitForSeconds(0.267f);
            Destroy(gameObject);
        }

        public void OnHit()
        {
         
            Enemy_animator.Hit();
            Health-=1;
            if (Health <= 0)
            {

                StartCoroutine(nameof(TimeToDestroy));
            }
        }
    

       
    }
}