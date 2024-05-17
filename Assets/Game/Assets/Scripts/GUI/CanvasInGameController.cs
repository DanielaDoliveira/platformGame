using System;
using UnityEngine;

namespace Game.Assets.Scripts.GUI
{
    public class CanvasInGameController: MonoBehaviour
    {
        public static CanvasInGameController instance;

        private void Awake()
        {
            if (instance is null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else if(instance != this)
            {
                Destroy(instance.gameObject);
                instance = this;
                DontDestroyOnLoad(this);
            }
        }
    }
}