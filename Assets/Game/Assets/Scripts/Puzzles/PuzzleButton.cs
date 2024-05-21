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
      
       [SerializeField] private AudioSource _source;
       private bool isPlayingMusic;
       private float timer = 0.208f;
[SerializeField]private AudioClip clip;
        public void Constructor(IPuzzleButton puzzleButton)
        {
            _puzzleButton = puzzleButton;
           
        }


        private void Start()
        {
            _puzzleButton.Anim = GetComponent<Animator>();
            _puzzleButton.Layer  = LayerMask.GetMask("PLAYER","STONE");
            _puzzleButton.BarrierAnim = BarrierAnimator ;
            _source = GetComponent<AudioSource>();
            isPlayingMusic = false;

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
               StartCoroutine(StartButtonSound());
                hit = null;
                
            }
            else
            {
                _puzzleButton.OnExit(_puzzleButton.Anim, _puzzleButton.BarrierAnim);
                isPlayingMusic = false;
                _source.Stop();
                    
            }
        }

        public IEnumerator StartButtonSound()
        {
            if (!isPlayingMusic)
            {
                isPlayingMusic = true;
                _source.PlayOneShot(clip);
                yield return new WaitForSeconds(timer);
                _source.Stop();
            }
            
            
        }
    }
}