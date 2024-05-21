
using System;
using System.Collections;
using UnityEngine.Events;

namespace Game.Assets.Scripts.Door
{
    public interface IDoor
    {
        public float Time { get; set; }
        public UnityEvent OnPassDoor { get; set; }
        
        /// <summary>
        /// Called when player touch the object with script. 
        /// </summary>
        /// <param name="callback">Function called that depends of door's goal.</param>
        public void OnGoal(Action loadFunction);
        /// <summary>
        /// Called when player goes to the next level
        /// </summary>
        /// <param name="time"> Time to load level</param>
        /// <param name="scene">Scene to load</param>
        /// <returns></returns>
        public IEnumerator LoadScene(float time, int scene);

        public void Load(int scene);
    }
}