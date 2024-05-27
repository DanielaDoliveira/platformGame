using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;
using Game.Assets.Scripts.Player.Singleton;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game.Assets.Scripts.System
{
    public class OnFinishGame: MonoBehaviour
    {
        public GameObject FinishPanel;
        private AudioSource _source;
        public UnityEvent OnFinish;
        public ProCamera2D Camera;
        public Transform player_target;
        public void Start()
        {
            _source = GetComponent<AudioSource>();
            FinishPanel.SetActive(false);
        }

        public IEnumerator Finish()
        {
            Camera.AddCameraTarget(player_target,10f,2f);
            Camera.Zoom(0.5f);
           
            _source.PlayOneShot(_source.clip);
            FinishPanel.SetActive(true);
            PlayerAudio.instance._AudioSource.Stop();//aquui
            OnFinish.Invoke();
            PlayerAudio.instance._AudioSource.mute = true;
         //   Destroy(PlayerAudio.instance.gameObject);
            yield return new WaitForSeconds(10f);
            Debug.Log("finish");
            SceneManager.LoadScene("Finish");
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                StartCoroutine(Finish());

            }
        }
    }
}