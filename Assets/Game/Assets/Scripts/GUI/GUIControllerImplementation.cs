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
           if(SceneManager.GetActiveScene().buildIndex<4)
                SceneManager.LoadScene(2);
           else
           {
               SceneManager.LoadScene(4);
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