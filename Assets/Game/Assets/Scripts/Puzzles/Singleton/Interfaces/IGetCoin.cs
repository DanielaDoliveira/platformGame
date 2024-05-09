namespace Game.Assets.Scripts
{
    public interface IGetCoin
    {
        public int CoinsNumber { get; set; }
        public bool IsGetCoin { get; set; }
        /// <summary>
        /// Function that RETURNS Coin Points of type INT
        /// </summary>
        /// <returns></returns>
        public int AddCoins( );
    }
}