
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
            GetComponent<Animator>().SetTrigger("hit");
        }

        public void Death()
        {
            GetComponent<Animator>().SetTrigger("dead");

        }
        public void Animate(GoblinEnum enemyState)
        {
            GetComponent<Animator>().SetInteger("transition",enemyState.GetHashCode());
 
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

    }
}