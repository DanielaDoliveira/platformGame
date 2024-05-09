using UnityEngine;

namespace Game.Assets.Scripts
{
    public class GetCoin: IGetCoin
    {
        public int CoinsNumber { get; set; }
        public bool IsGetCoin { get; set; }

        public int AddCoins()
        {
            CoinsNumber += 1;
            Debug.Log("Coins: "+CoinsNumber);
          
            return CoinsNumber;
        }
    }
}