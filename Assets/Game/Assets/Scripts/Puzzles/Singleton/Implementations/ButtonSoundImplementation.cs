using System;
using System.Collections;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Implementations
{
    public class ButtonSoundImplementation:IButtonSound
    {
        public bool IsPlayingMusic { get; set; } = false;
        public float Timer { get; set; } = 0.208f;
        public AudioSource Source { get; set; } 
        public AudioClip ButtonClip { get; set; }
        public IEnumerator StartButtonSound()
        {
            if (!IsPlayingMusic)
            {
                IsPlayingMusic = true;
                Source.PlayOneShot(ButtonClip);
                yield return new WaitForSeconds(Timer);
                Source.Stop();
            }
        }

      
    }
}