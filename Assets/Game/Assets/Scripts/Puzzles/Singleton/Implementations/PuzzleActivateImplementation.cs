using System.Collections;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles.Singleton.Implementations
{
    public  class PuzzleActivateImplementation: IPuzzleActivatePlatform
    {
        public GameObject PlatformTemp { get; set; }
        public float Time { get; set; }
    
    
        public void OnPressButton(Animator platformAnimator)
        {
            platformAnimator.Play("ground_idle");
            PlatformTemp.SetActive(true);
        
        }

        public IEnumerator WhileEnabledButton(Animator platformAnimator)
        { 
            yield return new WaitForSeconds(Time);
            platformAnimator.Play("ground_blinking");
            yield return new WaitForSeconds(Time);
            platformAnimator.Play("ground_idle");
            OnButtonDisabled();
        }

 

        public void OnButtonDisabled()
        {
            PlatformTemp.SetActive(false);
        }
    }
}