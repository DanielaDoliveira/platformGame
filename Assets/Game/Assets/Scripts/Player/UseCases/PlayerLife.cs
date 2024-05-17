using System;
using Game.Assets.Scripts.Exceptions;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Assets.Scripts.Player.UseCases
{

    public class PlayerLife : MonoBehaviour
    {
     
        private LayerMask layer;
        [SerializeField] private float radius;
       public static bool SceneLoaded ;
        public GameObject GameOverPanel;
        [Inject] private IPlayerLife _playerLife;
        [Inject] private IPlayerAnimator _playerAnimator;
        [Inject] private IPlayerFail _playerFail;

        public PlayerLife( IPlayerLife playerLife, IPlayerAnimator playerAnimator, IPlayerFail playerFail)
        {
            _playerLife = playerLife;
            _playerAnimator = playerAnimator;
            _playerFail = playerFail;
        }


        private void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex > 1)
            {
                if(GameOverPanel is null)
                    GameOverPanel = GameObject.FindGameObjectWithTag("Canvas");
            }
        }

        public void Start()
        {
           
            NullErrorException e = new NullErrorException("YOU FORGOT TO APPLY GameOverPanel REFERENCE LOCATED ON Canvas  ON SCRIPT PlayerLife");
            if(  GameOverPanel== null) 
                Debug.LogException(e,GameOverPanel);
            
            layer = LayerMask.GetMask("ENEMY", "SLIME", "GOBLIN");
            radius = 0.43f;
       
          _playerFail.GameOverPanel = GameOverPanel;
   
         
         _playerFail.GameOverPanel.SetActive(false);
            
            
        }

     

        public void OnHit()
        {
            StartCoroutine(_playerLife.HitTimeCounter(_playerAnimator, GetComponentInChildren<Animator>(),_playerFail.CallGameOver));
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            var tags = 
                        other.gameObject.CompareTag("ENEMY")
                       || 
                       other.gameObject.CompareTag("Slime") 
                       ||
                       other.gameObject.CompareTag("Goblin"); 
            
            if (tags)
                OnHit();
        
        }

        private void Update()
        {
            
            if ( SceneManager.GetActiveScene().buildIndex > 1 && !SceneLoaded)
            {
               
                if (GameOverPanel == null)
                {
               
                    GameOverPanel = GameObject.FindGameObjectWithTag("Canvas");
                    _playerFail.GameOverPanel = GameOverPanel;
                  GameOverPanel.SetActive(false);
                    SceneLoaded = true;
                }
                else if (GameOverPanel != null)
                {
                    GameOverPanel.SetActive(false);
                    SceneLoaded = true;
                }
                else
                {
                 
                    SceneLoaded = true;
                    
                }
                
            }
        }
    }
}

