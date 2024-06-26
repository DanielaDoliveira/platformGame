using System;
using System.Collections;
using Game.Assets.Scripts.Player;
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Player.UseCases;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class PlayerFailImplementation:IPlayerFail
    {
        [Inject] private IPlayerLife _playerLife;

        public PlayerFailImplementation(IPlayerLife playerLife)
        {
            _playerLife = playerLife;
        }

        public GameObject GameOverPanel { get; set; }
        public void CallEventOnFail(Action callback)
        {
            callback.Invoke();
        }

        public void CallGameOver()
        {
   
            GameOverPanel.SetActive(true);
        }


        public IEnumerator PlayerAnimationEventsOnFall(float time )
        {
            PlayerAudio.instance.PlaySfx(PlayerAudio.instance.HurtFx);
            if (PlayerPrefs.GetInt("HEALTH") <= 0 )
            {
                _playerLife.Health -= 1;
            }
            else
            {
                var _health = PlayerPrefs.GetInt("HEALTH");
                _health -= 1;
                _playerLife.Health = _health;
            }
            PlayerPrefs.SetInt("HEALTH", _playerLife.Health);
            var count = 0;
            while (count < time)

            {
                count += 1;
                yield return null;
            }

            if (_playerLife.Health <= 0)
            {
              
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerLife>().GameOverPanel.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
              
            }
            else
            {
                CallCheckpoint();
             
            }
           
       
                
           
              
               
             
                
         
        }
        public void CallCheckpoint()
        {
        
            PlayerPos.instance.InitialPosition();
           
        }


    }
}