
using UnityEngine;

namespace Game.Assets.Scripts.Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }


        public void Hit()
        {
            _animator.SetTrigger("hit");
        }

        public void Death()
        {
             _animator.SetTrigger("dead");

        }
        public void Animate(GoblinEnum enemyState)
        {
           _animator.SetInteger("transition",enemyState.GetHashCode());
 
        }

    }
}