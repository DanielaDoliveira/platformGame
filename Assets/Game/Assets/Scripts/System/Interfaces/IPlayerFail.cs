using System;
using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts
{
    public interface IPlayerFail
    {
        public void CallCheckpoint();
        public IEnumerator PlayerAnimationEventsOnFall(float time );
        public void CallEventOnFail(Action callback);
        
    }
}