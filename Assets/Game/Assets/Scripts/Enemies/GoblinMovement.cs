
using System;
using Game.Assets.Scripts.Player.UseCases;
using Platformer.Assets.Game.Scripts.Player.UseCases;
using UnityEngine;



namespace Game.Assets.Scripts.Enemies
{
    public class GoblinMovement : Enemy
    {
          private bool _isRight, _isFront;
        
        public float maxVision;
        public Transform point;
        public Transform pointBehind;
        private Vector3 _rayPosition;
        private Vector2 _direction;
        private float _stopDistance = 0.8f;
   

       private void Start()
        {
            base.Start();
           // _isRight = true;
            Speed = 2;
            VerifyPosition();
            Rb2d = GetComponent<Rigidbody2D>();
            Enemy_animator = GetComponent<EnemyAnimator>();
  
        }
        void VerifyPosition()
        {
            if (_isRight)
            {
                transform.eulerAngles = new Vector2(0, 0);
                _direction = Vector2.right;
               

            }
            else
            {
                
                transform.eulerAngles = new Vector2(0, 180);
                _direction = Vector2.left;
             
            }
        }

        private void OnMove()
        {
           
            if (_isFront)
            {
               
                Enemy_animator.Animate(GoblinEnum.Walk);
                VerifyPosition();
             if(_isRight)
                 Rb2d.velocity = new Vector2(Speed, Rb2d.velocity.y);
             else
                 Rb2d.velocity = new Vector2(-Speed, Rb2d.velocity.y);
            }
            else
            {
                Enemy_animator.Animate(GoblinEnum.Idle);
                Rb2d.velocity = Vector2.zero;
            }
        }


        private void FixedUpdate()
        {
            OnMove();
            GetPlayer();
            GetPlayerBehind();
           
        }

        private void Update()
        {
          

        }

        private void GetPlayer()
        {
            var hit = Physics2D.Raycast(point.position,_direction,maxVision);
    
            var isHitNotNull = hit.collider != null;

            if (hit.collider is not null  )
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("PLAYER"))
                {
                    Debug.Log("Seeing player");
                    _isFront = true;
                    var distance = Vector2.Distance(transform.position, hit.transform.position);
                    if (distance <= _stopDistance)
                    {
                        _isFront = false;
                        Rb2d.velocity = Vector2.zero;
                        Enemy_animator.Animate(GoblinEnum.Attack);
                        hit.transform.GetComponent<PlayerLife>().OnHit();
                    }
                }
         
             
              
              
              
            }
          
            else
            {
                _isFront = false;
            }

        }
/// <summary>
/// Function called when Player has behind of enemy
/// </summary>
        private void GetPlayerBehind()
        { 
            
         
            var behindHit = Physics2D.Raycast(pointBehind.position,  - _direction, maxVision);
        
            if (behindHit.collider!= null)
            {
                if (behindHit.transform.gameObject.layer == LayerMask.NameToLayer("PLAYER") )
                {
                    Debug.Log("Seeing player behind");
                    _isRight = !_isRight;
                    _isFront = true;
                    
                }
                
             
                else
                {
                    _isFront = false;
                }
            }
        }

        

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(point.position,_direction *maxVision);
            Gizmos.DrawRay(pointBehind.position,- _direction *maxVision);
        }

        
    }  
}

