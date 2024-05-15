using System.Collections;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Interfaces
{
    public interface IPuzzleActivatePlatform
    {
        public GameObject PlatformTemp { get; set; }
        public float Time { get; set; }
        
        /// <summary>
        /// Determines the event when player press button
        /// </summary>
        public void OnPressButton(Animator platformAnimator);
        /// <summary>
        /// Determines the event while button be activated
        /// </summary>
        /// <param name="platformAnimator"> Animator of GameObject(platform)</param>
        /// <returns></returns>
        public IEnumerator WhileEnabledButton(Animator platformAnimator);
        /// <summary>
        /// Event called when button to be disabled
        /// </summary>
        public void OnButtonDisabled();

    }
}