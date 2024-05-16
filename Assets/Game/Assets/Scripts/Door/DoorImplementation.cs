using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.Door
{
    public class DoorImplementation:IDoor
    {
        public float Time { get; set; }
        
      
        public void OnGoal(Action callback)
        {
            callback.Invoke();
        }
   
        public IEnumerator LoadScene(float time, int scene)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(scene);
        }
    }
}