using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.GUI
{
    public class GUIControllerImplementation:IGUIController
    {
        public void RestartScene()
        {
           if(SceneManager.GetActiveScene().buildIndex<3)
                SceneManager.LoadScene(1);
           else
           {
               SceneManager.LoadScene(3);
           }
        }

        public void PlayGame()
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void IntroMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public IEnumerator DelayAndStartScene(float time,Action function)
        {
            yield return new WaitForSeconds(time);
            function.Invoke();
            
        }
    }
}