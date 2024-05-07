using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Enemies
{
    public class SlimeLife:Enemy
    {

       
        
        [Inject]
        private IEnemyLife _enemyLife;
        public void Construct(IEnemyLife enemyLife)
        {
            _enemyLife = enemyLife;
        }

        void Start()
        {
            Health = 2;
            _enemyLife.Health = Health;
        }
        
        public void OnHit()
        {
          Debug.Log("Slime "+Health);
            _enemyLife.OnHit(Speed,GetComponent<EnemyAnimator>());
        }

       
    }
}