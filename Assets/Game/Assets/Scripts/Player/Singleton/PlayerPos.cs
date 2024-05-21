using System;
using Platformer.Assets.Game.Scripts.Player.UseCases.Controller;
using UnityEngine;

namespace Game.Assets.Scripts.Player
{
    public class PlayerPos:MonoBehaviour
    {
        private Transform player;
        public static PlayerPos instance;
        private  PlayerController _playerController;
        private void Awake()
        {
     
              instance = this;
     
        }

        private void Start()
        {
            _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            _playerController.enabled = true;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            InitialPosition();
        }

        public void InitialPosition()
        {
            if (player != null)
                player.position = transform.position;
        }
    }
}