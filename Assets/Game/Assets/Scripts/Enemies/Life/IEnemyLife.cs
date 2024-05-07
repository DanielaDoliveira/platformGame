using System.Collections;

namespace Game.Assets.Scripts.Enemies
{
    public interface IEnemyLife
    {
        public int Health { get; set; }
     
        /// <summary>
        /// Redefine the velocity of ENEMY and destroy it at defined time 
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="enemyAnimator"></param>
        /// <returns></returns>
        IEnumerator TimeToDestroy(float speed, EnemyAnimator enemyAnimator);

        /// <summary>
        /// Event called when ENEMY Collides with Attack of Player 
        /// </summary>
        /// <param name="health"></param>
        /// <param name="speed"></param>
        /// <param name="enemyAnimator"></param>
        void OnHit( float speed, EnemyAnimator enemyAnimator); 
      

 
    }
}