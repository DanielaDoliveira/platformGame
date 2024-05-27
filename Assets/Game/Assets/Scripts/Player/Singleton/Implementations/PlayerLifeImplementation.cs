using System;
using System.Collections;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Player.UseCases;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Player.Singleton.Implementations
{
    public class PlayerLifeImplementation: IPlayerLife
    {

        public int Health { get; set; } = 3;
       
        public bool Recovery { get; set; }
        public float RecoveryCount { get; set; } = 3f;
        
   
     
        public IEnumerator HitTimeCounter( IPlayerAnimator playerAnimator, Animator animator, Action gameOverFunction)
        {
            var timeToEndDeadAnimator = 0.6f;
           Recovery = true;
           playerAnimator.Hit(animator);
           Health -= 1;
            
            yield return new WaitForSeconds(RecoveryCount * Time.deltaTime);
            Recovery = false;
            if (Health <= 0 && !Recovery)
            {
                Recovery = true;
                playerAnimator.Dead(animator);
                yield return new WaitForSeconds(timeToEndDeadAnimator);
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                gameOverFunction.Invoke();
                PlayerPrefs.SetInt("HEALTH", 3);
                
            }
            PlayerPrefs.SetInt("HEALTH",Health);
        }

     

     
      
    }
}