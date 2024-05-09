using System.Collections;
using Game.Assets.Scripts.Player.Singleton.Interfaces;

using UnityEngine;

namespace Game.Assets.Scripts.Player.Singleton.Implementations
{
    public class PlayerLifeImplementation: IPlayerLife
    {

        public int Health { get; set; } = 3;
        public bool Recovery { get; set; }
        public float RecoveryCount { get; set; } = 2f;

     
        public IEnumerator HitTimeCounter( PlayerAnimator animator)
        {   
      
       Recovery = true;
           animator.Hit();
           Health -= 1;
            Debug.Log("Health: "+Health);
            yield return new WaitForSeconds(RecoveryCount * Time.deltaTime);
            Recovery = false;
            if (Health <= 0 && !Recovery)
            {
                Recovery = true;
               animator.Dead();
                
            }
        }

     
      
    }
}