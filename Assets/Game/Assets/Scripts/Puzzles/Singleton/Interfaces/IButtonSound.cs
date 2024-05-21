using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Interfaces
{
    public interface IButtonSound
    {
        public bool IsPlayingMusic { get; set; }
        public float Timer { get; set; } 
        public AudioSource Source { get; set; }
        public AudioClip ButtonClip { get; set; }
        public IEnumerator StartButtonSound();
    }
}