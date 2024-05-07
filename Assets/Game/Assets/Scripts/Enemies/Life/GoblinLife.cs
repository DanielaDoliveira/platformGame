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
        }
        
        public void OnHit()
        {
            Health -= 1;
            _enemyLife.OnHit(Health,Speed,GetComponent<EnemyAnimator>());
        }
    }
}