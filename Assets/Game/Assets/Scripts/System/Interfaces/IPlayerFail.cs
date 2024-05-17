using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Assets.Scripts
{
    public interface IPlayerFail
    {
        public void CallCheckpoint();
        public GameObject GameOverPanel { get; set; }
        public IEnumerator PlayerAnimationEventsOnFall(float time );
        public void CallEventOnFail(Action callback);
        public void CallGameOver( );
        

    }
}