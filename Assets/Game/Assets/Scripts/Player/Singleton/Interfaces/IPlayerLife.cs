using System;
using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts.Player.Singleton.Interfaces
{
    public interface IPlayerLife
    {
        public int Health { get; set; }
      
        public bool Recovery { get; set; }
        public float RecoveryCount { get; set; }
        
       
     /// <summary>
     /// Coroutine of Player Damage 
     /// </summary>
     /// <param name="animator">Player Animator script</param>
     /// <returns></returns>
        public IEnumerator HitTimeCounter( IPlayerAnimator playerAnimator, Animator animator, Action callGameOverFunction);

     


    }
}