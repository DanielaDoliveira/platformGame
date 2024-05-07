using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Enemies
{
    public class GoblinLife:Enemy
    {    
      
        [Inject]
        private IEnemyLife _enemyLife;
        public  void Construct(IEnemyLife enemyLife)
        {
            _enemyLife = enemyLife;
        }

        void Start()
        {
            Health = 3;
            _enemyLife.Health = Health;
        
        }
        
        public void OnHit()
        {
       
            _enemyLife.OnHit(Speed,GetComponent<EnemyAnimator>());
        
        }
    }
}