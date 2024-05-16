using System;
using System.Collections;
using Game.Assets.Scripts.Player;
using UnityEngine;

namespace Game.Assets.Scripts
{
    public class PlayerFailImplementation:IPlayerFail
    {
        
        public void CallEventOnFail(Action callback)
        {
            callback.Invoke();
        }



        public IEnumerator PlayerAnimationEventsOnFall(float time )
        {
           
            var count = 0;
            while (count < time)

            {
                count += 1;
                yield return null;
            }
            CallCheckpoint();
       
                
           
              
               
             
                
         
        }
        public void CallCheckpoint()
        {
        
            PlayerPos.instance.InitialPosition();
           
        }

    }
}