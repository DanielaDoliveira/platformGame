using System;
using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles
{
    public class PlatformSound: MonoBehaviour
    {
        private AudioSource _source;
        public AudioClip Clip;
        private float timer;
        private bool isCoroutine;
        public void Start()
        {
            _source = GetComponent<AudioSource>();
            StartCoroutine(PlaySound());

        }

        public IEnumerator PlaySound()
        {
            if (!isCoroutine)
            {
                _source.PlayOneShot(Clip);
                yield return new WaitForSeconds(timer);
                _source.Stop();
            }
           
        }
        
    }
}