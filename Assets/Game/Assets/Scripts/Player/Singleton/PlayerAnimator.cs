using Platformer.Assets.Game.Scripts.Player.Enum;
using UnityEngine;

namespace Game.Assets.Scripts.Player.Singleton
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



        public void Animate(PlayerEnum playerType)
        {
            Platformer.Assets.Game.Scripts.Player.Singleton.Player.Animator.SetInteger("transition",playerType.GetHashCode());
 
        }

        public void Hit()
        {
            Platformer.Assets.Game.Scripts.Player.Singleton.Player.Animator.SetTrigger("hit");
        }

        public void Dead()
        {
            Platformer.Assets.Game.Scripts.Player.Singleton.Player.Animator.SetTrigger("dead");
        }
    }
}