using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Assets.Game.Scripts.Player
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public static Rigidbody2D _Rigidbody2D;
        void Start()
        {
            _Rigidbody2D = GetComponent<Rigidbody2D>();
        }

       
    }

}