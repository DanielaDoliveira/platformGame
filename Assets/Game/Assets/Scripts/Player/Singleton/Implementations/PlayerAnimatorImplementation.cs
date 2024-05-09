using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Platformer.Assets.Game.Scripts.Player.Enum;
using UnityEngine;

namespace Game.Assets.Scripts.Player.Singleton.Implementations
{
    public class PlayerAnimatorImplementation: IPlayerAnimator
    {
        
        
      


        public void Animate(PlayerEnum playerType, Animator animator)
        {
            animator.SetInteger("transition",playerType.GetHashCode());
 
        }

        public void Hit(Animator animator)
        {
           animator.SetTrigger("hit");
        }

        public void Dead(Animator animator)
        {
             animator.SetTrigger("dead");
        }
        
    }
}