using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts
{
    public class SplashScreen: MonoBehaviour
    {
        public float TimerToNextScreen;
        private void Start()
        {
            StartCoroutine(nameof(StartScene));
        }

        private IEnumerator StartScene()
        {
        
            yield return new WaitForSeconds(TimerToNextScreen);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}