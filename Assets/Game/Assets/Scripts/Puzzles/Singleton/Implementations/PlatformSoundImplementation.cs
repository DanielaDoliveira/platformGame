using System.Collections;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Implementations
{
    public class PlatformSoundImplementation: IPlatformSound
    {
        public AudioSource Source { get; set; }
        public AudioClip Clip { get; set; }
        public AudioClip ClipFast { get; set; }
        public float Timer { get; set; } = 5.8f;
        public bool IsCoroutine { get; set; }
        public IEnumerator PlaySound()
        {
           
            if (!IsCoroutine)
            {
                IsCoroutine = true;
             
                PlayFx(Source,Clip,1f);
                yield return new WaitForSeconds(Timer);
                 Source.Stop();
                 PlayFx(Source,ClipFast,0.3f);
                yield return new WaitForSeconds(5);
                Source.Stop();
                IsCoroutine = false;
            }
        }

        public void PlayFx(AudioSource source,AudioClip clip , float volume)
        {
            source.loop = true;
            source.volume = volume;
            source.clip = clip;
            source.Play();
        }

        public void StopAll()
        {
            Source.Stop();
        }
    }
}