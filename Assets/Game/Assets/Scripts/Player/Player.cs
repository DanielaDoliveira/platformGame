using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Platformer.Assets.Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
       [SerializeField] private float _speed;
       private float _movement;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void FixedUpdate()
        {
            Move();
            Flip();
        }

        void Move()
        {
         _movement = Input.GetAxis("Horizontal");
         _rigidbody2D.velocity = new Vector2(_movement * _speed,_rigidbody2D.velocity.y);

        }

        void Flip()
        {
            transform.eulerAngles = _movement switch
            {
                > 0 => new Vector3(0, 0, 0),
                < 0 => new Vector3(0, 180, 0),
                _ => transform.eulerAngles
            };
        }
    }

}