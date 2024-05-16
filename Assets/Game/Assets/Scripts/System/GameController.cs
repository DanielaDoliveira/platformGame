    using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GameController: MonoBehaviour
    {


        public TextMeshProUGUI PointsText;
        public int Points { get; set; }
        [Inject]
        private IGetCoin _getCoin;
        public void Constructor(IGetCoin getCoin)
        {
            _getCoin = getCoin;
        }
        

        public void Start()
        {
            Points = _getCoin.CoinsNumber;
        }

        private void Update()
        {
           GetPointsReference();
              
            
        }

        private void GetPointsReference()
        {
            
            Points = _getCoin.CoinsNumber;
            PointsText.text = Points.ToString();
        }
    }
}