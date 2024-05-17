using System;
using System.Collections;
using System.Threading.Tasks;
using Game.Assets.Scripts.Player;
using Game.Assets.Scripts.Player.Singleton;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using ModestTree;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class Coin: MonoBehaviour
    {
        [Inject]
        private IGetCoin _getCoin;

      
      

        public int Points { get; set; }
       
        public void Constructor(IGetCoin getCoin )
        {
            _getCoin = getCoin;
           
        }

        public void Start()
        {
          
        }

        private IEnumerator OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _getCoin.IsGetCoin = true;
                if (_getCoin.IsGetCoin)
                {
                    GetComponent<Animator>().SetTrigger("hit");
                    Points = _getCoin.AddCoins();
                    PlayerAudio.instance.PlaySfx(PlayerAudio.instance.CoinFx);
                    Debug.Log("Points: "+Points);
                }
                _getCoin.IsGetCoin = false;
                yield return new WaitForSeconds(0.5f);
                Destroy(gameObject);
              
            
                
            }

            _getCoin.IsGetCoin = false;
            
        }
    }
}