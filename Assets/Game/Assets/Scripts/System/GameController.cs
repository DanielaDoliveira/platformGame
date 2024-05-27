    using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GameController: MonoBehaviour
    {


        public TextMeshProUGUI PointsText;
        public int Points { get; set; }
        [Inject]
        private IGetCoin _getCoin;

        public UnityEvent OnRestartScene;
        public void Constructor(IGetCoin getCoin)
        {
            _getCoin = getCoin;
        }
        

        public void Start()
        {
         //   PlayerPrefs.DeleteAll();
         OnRestartScene.Invoke();
         PointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
            Points = _getCoin.CoinsNumber;
            if (PlayerPrefs.GetInt("COINS") > 0)
            {
                _getCoin.CoinsNumber = PlayerPrefs.GetInt("COINS");
                Points = _getCoin.CoinsNumber;
                PointsText.text = "x "+ Points.ToString();
            }
     
                
                
        }

        private void Update()
        {
           GetPointsReference();
              
            
        }

        private void GetPointsReference()
        {
            
            Points = _getCoin.CoinsNumber;
             PointsText.text = "x "+ Points.ToString();
            SaveChanges();
        }

        private void SaveChanges()
        {
            PlayerPrefs.SetInt("COINS",Points);
           
        }
    }
}