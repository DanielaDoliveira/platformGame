using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Com.LuisPedroFonseca.ProCamera2D;
using Platformer.Assets.Game.Scripts.Player.UseCases.Controller;
using UnityEngine.Events;


namespace Game.Assets.Scripts.Door
{
    [RequireComponent(typeof(AudioSource))]
    public class DoorNextLevel:MonoBehaviour
    {
        private float Time  = 1.5f;
        private AudioSource _source;
        public UnityEvent OnPassDoor;
        [Inject] private IDoor _door;
        
        public void Construct(IDoor door)
        {
            _door = door;
        }

        private void Start()    
        {
            _door.Time = Time;
            _door.OnPassDoor = OnPassDoor;
            _source = GetComponent<AudioSource>();

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
      //  _door.Load(scene);
            _source.PlayOneShot(_source.clip);
            StartCoroutine(_door.LoadScene(Time, scene));
        }

      
      


        
    }
}