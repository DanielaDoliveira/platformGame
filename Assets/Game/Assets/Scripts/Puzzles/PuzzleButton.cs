using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Puzzles
{
    public class PuzzleButton:MonoBehaviour
    {
        public Animator BarrierAnimator;

        [Inject] private IPuzzleButton _puzzleButton;

        public void Constructor(IPuzzleButton puzzleButton)
        {
            _puzzleButton = puzzleButton;
           
        }


        private void Start()
        {
            _puzzleButton.Anim = GetComponent<Animator>();
            _puzzleButton.Layer  = LayerMask.GetMask("PLAYER","STONE");
            _puzzleButton.BarrierAnim = BarrierAnimator ;
        }

        public void FixedUpdate()
        {
            OnCollision();
        }
        
        public void OnCollision()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 1, _puzzleButton.Layer);
            if (hit != null)
            {
               _puzzleButton.OnPressed(_puzzleButton.Anim, _puzzleButton.BarrierAnim);
                hit = null;
            }
            else
            {
                _puzzleButton.OnExit(_puzzleButton.Anim, _puzzleButton.BarrierAnim);
            }
        }
    }
}