using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Player.UseCases;
using Platformer.Assets.Game.Scripts.Player.UseCases.Controller;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts.GUI
{
    public class GUIController: MonoBehaviour
    {
        private float timerToDelay = 0f;
        [Inject] private IGUIController _guiController;

        public void Constructor (IGUIController guiController)
        {
            _guiController = guiController;
     
        }

        public void OnRestartScene()
        {
            
            PlayerLife.SceneLoaded = false;
            //
            _guiController.RestartScene();
            
        
          
         
        }

        public void OnPlay()
        {
            PlayerLife.SceneLoaded = false;
            PlayerPrefs.DeleteKey("COINS");
            PlayerPrefs.DeleteKey("HEALTH");
           _guiController.PlayGame();
        }

        public void MainMenu()
        {
            _guiController.IntroMenu();
        }

        public void OnExit()
        {
            StartCoroutine(_guiController.DelayAndStartScene(timerToDelay, _guiController.ExitGame));
        }
    }
}