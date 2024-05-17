using System;

using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Platformer.Assets.Game.Scripts.Player.UseCases.Controller
{
    public class PlayerController:MonoBehaviour
    {

        private PlayerJump _playerJump;
         private PlayerAttack _playerAttack;
        private PlayerMovement _playerMovement;


        private PlayerController player;

        private void Awake()
        {
           
            if (player is null)
            {
                player = this;
                DontDestroyOnLoad(this);
            }
            else if(player != this)
            {
                Destroy(player.gameObject);
                player = this;
                DontDestroyOnLoad(this);
            }
               
            
        }

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerJump = GetComponent<PlayerJump>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        public void FixedUpdate()
        {
   
            _playerMovement.Execute();
        }

        public void Update()
        {
            Inputs();
        }

        public void Inputs()
        {
            if (Input.GetButtonDown("Jump"))
            {
                
                _playerJump.Execute();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _playerAttack.Execute();
            }
        }
    }
}