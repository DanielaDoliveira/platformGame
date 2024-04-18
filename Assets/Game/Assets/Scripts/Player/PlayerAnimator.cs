using System;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        public PlayerEnum PlayerType;
        public static PlayerAnimator instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
           
        }

    

        public void Animate(PlayerEnum playerType)
        {
            _animator.SetInteger("transition",playerType.GetHashCode());
 
        }
    }
}