using System.Collections;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Enemies
{
    public class EnemyLife: IEnemyLife
    {
     
        public EnemyAnimator EnemyAnimator { get; set; }

        // ReSharper disable Unity.PerformanceAnalysis
        public int Health { get; set; }
        public float Speed { get; set; }
        public bool isDead = false;
    

        public IEnumerator TimeToDestroy(float speed,EnemyAnimator enemyAnimator)
        {
           
            speed = 0;
            enemyAnimator.Death();
            yield return new WaitForSeconds(0.267f);
            enemyAnimator.DestroyObject();
            
        }


        // ReSharper disable Unity.PerformanceAnalysis
        public void OnHit( float Speed, EnemyAnimator enemyAnimator)
        {

       
            Health -= 1;
            
           if(!isDead) 
               enemyAnimator.Hit();
    
            if (Health <= 0)
            {
                isDead = true;
                enemyAnimator.StartCoroutine(TimeToDestroy(Speed, enemyAnimator));
            }
        }

     
    }
    }
