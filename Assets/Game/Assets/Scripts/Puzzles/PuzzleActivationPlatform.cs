using System;
using System.Collections;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Puzzles
{
    public class PuzzleActivationPlatform: MonoBehaviour
    {
        public float Count;
        public GameObject PlatformTemp;
        public Animator PlatformAnimator;
        public AudioClip clip;
        private Animator _animator;
        private bool isCoroutine;
        [Inject] private IButtonSound _buttonSound;
        
    

        public PuzzleActivationPlatform( IButtonSound buttonSound)
        {
           
            _buttonSound = buttonSound;
        }

        
        public void Start()
        {
            _animator = GetComponent<Animator>();
            isCoroutine = false;
            PlatformTemp.SetActive(false);
            _buttonSound.IsPlayingMusic = false;
            _buttonSound.Source = GetComponent<AudioSource>();
            _buttonSound.ButtonClip = clip;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(!isCoroutine)
                    StartCoroutine(OnPressButton());

            }
            
        }
        public IEnumerator WhileEnabledButton()
        { 
            yield return new WaitForSeconds(Count);
            PlatformAnimator.Play("ground_blinking");
            yield return new WaitForSeconds(Count);
            PlatformAnimator.Play("ground_idle");
            OnButtonDisabled();
        }

        public void OnButtonDisabled()
        {
            _animator.SetBool("isPressed",false);
            PlatformTemp.SetActive(false);
            _buttonSound.IsPlayingMusic = false;
            isCoroutine = false;
          
        }
        public IEnumerator OnPressButton()
        {
            isCoroutine = true;
            _animator.SetBool("isPressed",true);
            StartCoroutine(_buttonSound.StartButtonSound());
            PlatformAnimator.Play("ground_idle");
            PlatformTemp.SetActive(true);
            yield return new WaitForSeconds(1f);
            StartCoroutine(WhileEnabledButton());

        }

    }
}