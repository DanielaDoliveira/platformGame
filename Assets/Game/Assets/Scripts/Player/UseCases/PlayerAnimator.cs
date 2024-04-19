using System;
using Platformer.Assets.Game.Scripts.Player.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player.UseCases
{
    public class PlayerAnimator : MonoBehaviour
    {
     
        
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
          
           
        }

    

        public void Animate(PlayerEnum playerType)
        {
            Singleton.Player.Animator.SetInteger("transition",playerType.GetHashCode());
 
        }
    }
}