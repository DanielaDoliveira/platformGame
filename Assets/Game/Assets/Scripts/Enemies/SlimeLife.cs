using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    public class SlimeLife:Enemy
    {

        void Start()
        {
            Health = 3;
        }
        IEnumerator TimeToDestroy()
        {
            Speed = 0;
            GetComponent<EnemyAnimator>().Death();
            yield return new WaitForSeconds(0.267f);
            Destroy(gameObject);
        }

        public void OnHit()
        {
         
           GetComponent<EnemyAnimator>().Hit();
            Health-=1;
            if (Health <= 0)
            {

                StartCoroutine(nameof(TimeToDestroy));
            }
        }
    }
}