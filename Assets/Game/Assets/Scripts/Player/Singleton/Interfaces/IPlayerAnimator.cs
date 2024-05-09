using Platformer.Assets.Game.Scripts.Player.Enum;
using UnityEngine;

namespace Game.Assets.Scripts.Player.Singleton.Interfaces
{
    public interface IPlayerAnimator
    {
       
        public void Animate(PlayerEnum playerType, Animator animator);
        public void Hit(Animator animator);
        public void Dead(Animator animator);
    }
}