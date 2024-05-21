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
        public AudioClip ClipPlatform;
        public AudioClip ClipPlatformFast;
        private bool isCoroutine;
        [Inject] private IButtonSound _buttonSound;
        [Inject] private IPlatformSound _platformSound;

        public PuzzleActivationPlatform(IButtonSound buttonSound, IPlatformSound platformSound)
        {
            _buttonSound = buttonSound;
            _platformSound = platformSound;
        }


       

        
        public void Start()
        {
            _animator = GetComponent<Animator>();
            isCoroutine = false;
            _platformSound.IsCoroutine = false;
            _platformSound.Source = GameObject.FindWithTag("PlatformSound").GetComponent<AudioSource>();
            _platformSound.Clip = ClipPlatform;
            _platformSound.ClipFast = ClipPlatformFast;
            PlatformTemp.SetActive(false);
            _buttonSound.IsPlayingMusic = false;
            _buttonSound.Source = GetComponent<AudioSource>();
            _buttonSound.ButtonClip = clip;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!isCoroutine)
                    StartCoroutine(OnPressButton());
                
                StartCoroutine(_platformSound.PlaySound());

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