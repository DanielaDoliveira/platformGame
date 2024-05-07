using System;
using System.Collections;
using System.Threading.Tasks;
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
       
        public void Constructor(IGetCoin getCoin)
        {
            _getCoin = getCoin;
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