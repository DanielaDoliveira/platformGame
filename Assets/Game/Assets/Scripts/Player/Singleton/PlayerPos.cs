using System;
using UnityEngine;

namespace Game.Assets.Scripts.Player
{
    public class PlayerPos:MonoBehaviour
    {
        private Transform player;
        public static PlayerPos instance;

        private void Awake()
        {
     
              instance = this;
     
        }

        private void Start()
        {
         
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