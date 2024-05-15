using System;
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
        [Inject] private IPuzzleActivatePlatform _activatePlatform;

        public void Constructor(IPuzzleActivatePlatform activatePlatform)
        {
            _activatePlatform = activatePlatform;
        }

        public void Start()
        {
           
            _activatePlatform.Time = Count;
            _activatePlatform.PlatformTemp = PlatformTemp;
            _activatePlatform.PlatformTemp.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _activatePlatform.OnPressButton(PlatformAnimator);
                StartCoroutine(_activatePlatform.WhileEnabledButton(PlatformAnimator));
            }
                
            
        }
    }
}