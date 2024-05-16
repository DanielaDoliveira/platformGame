using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Assets.Scripts.Door
{
    public class DoorNextLevel:MonoBehaviour
    {
        public float Time  = 5f;
        [Inject] private IDoor _door;

        public void Construct(IDoor door)
        {
            _door = door;
        }

        private void Start()
        {
            _door.Time = Time;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           
            if (other.gameObject.CompareTag("Player"))
            {
                _door.OnGoal(LoadNextLevel);
            }
        }

        public void LoadNextLevel()
        {
            var scene = SceneManager.GetActiveScene().buildIndex + 1;
            StartCoroutine(_door.LoadScene(Time, scene));
        }


        
    }
}