using System.Collections;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    public class EnemyLife: IEnemyLife
    {
     
        public EnemyAnimator EnemyAnimator { get; set; }

        // ReSharper disable Unity.PerformanceAnalysis
        public IEnumerator TimeToDestroy(float speed,EnemyAnimator enemyAnimator)
        {
            speed = 0;
            enemyAnimator.Death();
            yield return new WaitForSeconds(0.267f);
            enemyAnimator.DestroyObject();
        }


        // ReSharper disable Unity.PerformanceAnalysis
        public void OnHit(int health, float Speed, EnemyAnimator enemyAnimator)
        {

            
            enemyAnimator.Hit();
        
            if (health <= 0)
            {
                enemyAnimator.StartCoroutine(TimeToDestroy(Speed, enemyAnimator));
            }
        }

     
    }
    }