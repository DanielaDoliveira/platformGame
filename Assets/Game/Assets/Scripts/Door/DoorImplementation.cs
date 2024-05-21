using System;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.Door
{
    public class DoorImplementation:IDoor
    {
        public float Time { get; set; } = 0f;
        public UnityEvent OnPassDoor { get; set; }


        public void OnGoal(Action callback)
        {
            callback.Invoke();
        }
   
        public IEnumerator LoadScene(float time, int scene)
        {
            OnPassDoor.Invoke();
            yield return new WaitForSeconds(time);
          
            SceneManager.LoadScene(scene);
        }

        public void Load( int scene)
        {
            OnPassDoor.Invoke();
            SceneManager.LoadScene(scene);
        }
    }
}