
using System;
using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    public class Slime: Enemy
    {
        [SerializeField]private Transform point;
        [SerializeField] private float radius;
        [SerializeField]private LayerMask layer;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        private int health;
     

        void Start()
        {
            base.Start();
            speed = -1.5f;
            health = 3;
            EnemyLayer = LayerMask.NameToLayer("ENEMY");
            _enemyAnimator = GetComponent<EnemyAnimator>();
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
            SlimeFlip();
           
         
        }

        void SlimeFlip()
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

        public void OnHit()
        {
            _enemyAnimator.Hit();
            health-=1;
            if (health <= 0)
            {
                _enemyAnimator.Death();
                Destroy(gameObject,0.3f);
            }
        }
    }
}