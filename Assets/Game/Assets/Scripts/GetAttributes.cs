using System;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GetAttributes:MonoBehaviour
    {

   
        public static GetAttributes instance;
    
        private void Awake()
        {
            // if (instance == null)
            // {
            //     instance = this;
            // }
            // else
            // {
            //     Destroy(instance);
            // }
            // DontDestroyOnLoad(instance);
        }
    }
}