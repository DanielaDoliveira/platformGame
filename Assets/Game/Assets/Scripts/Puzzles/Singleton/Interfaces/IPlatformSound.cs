using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Interfaces
{
    public interface IPlatformSound
    {
        public AudioSource Source { get; set; }
        public AudioClip Clip{ get; set; }
        public AudioClip ClipFast{ get; set; }
        public float Timer{ get; set; }
        public bool IsCoroutine{ get; set; }
        public IEnumerator PlaySound();
    }
}