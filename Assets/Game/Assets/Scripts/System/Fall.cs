using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using Zenject;

namespace Game.Assets.Scripts
{
    public class Fall: MonoBehaviour
    {
        public Animator playerAnimator;
        public float TimeToRecover ;
        [Inject] private IPlayerFail _playerFail;

        public void Constructor(IPlayerFail playerFail)
        {
            _playerFail = playerFail;
        }

        public void Start()
        {
            playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
            TimeToRecover = 5f;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
          _playerFail.CallEventOnFail(CallFallEvent);
        }

        public void CallFallEvent()
        {
            StartCoroutine(_playerFail.PlayerAnimationEventsOnFall(TimeToRecover));
        }
   
    }
}