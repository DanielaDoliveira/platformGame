using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.Player.Singleton
{
    public class PlayerAudio: MonoBehaviour
    {
        public  AudioSource _AudioSource;
        public AudioClip JumpFx;
        public  AudioClip HitFx;
        public  AudioClip CoinFx;
        public AudioClip HurtFx;
        public static PlayerAudio instance;
        private void Awake()
        {
            if (instance is null)
            {  
                instance = this;
                DontDestroyOnLoad(instance);
                
            }
            else if (instance != this)
            {
                Destroy(instance.gameObject);
                instance = this;
                DontDestroyOnLoad(instance);
            }
               
         
            
        }

        private void Start()
        {
            _AudioSource = GetComponent<AudioSource>();
            
        }
        public void PlaySfx(AudioClip sound)
        {
            _AudioSource.PlayOneShot(sound);
        }
     
    }
}