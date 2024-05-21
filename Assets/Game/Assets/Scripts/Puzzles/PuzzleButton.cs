using System.Collections;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Puzzles
{
    public class PuzzleButton:MonoBehaviour
    {
        public Animator BarrierAnimator;
   
     
        [Inject] private IPuzzleButton _puzzleButton;
        [Inject] private IButtonSound _buttonSound;
     
      
     
        [SerializeField]private AudioClip clip;
        public PuzzleButton(IPuzzleButton puzzleButton, IButtonSound buttonSound)
        {
            _puzzleButton = puzzleButton;
            _buttonSound = buttonSound;
        }

        private void Start()
        {
            _puzzleButton.Anim = GetComponent<Animator>();
            _puzzleButton.Layer  = LayerMask.GetMask("PLAYER","STONE");
            _puzzleButton.BarrierAnim = BarrierAnimator ;
            _buttonSound.Source = GetComponent<AudioSource>();
            _buttonSound.ButtonClip = clip;
           
            

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
               StartCoroutine(_buttonSound.StartButtonSound());
                hit = null;
                
            }
            else
            {
                _puzzleButton.OnExit(_puzzleButton.Anim, _puzzleButton.BarrierAnim);
                _buttonSound.IsPlayingMusic = false;
              _buttonSound.Source.Stop();
            }
        }

      
    }
}