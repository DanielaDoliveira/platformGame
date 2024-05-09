using UnityEngine;

namespace Game.Assets.Scripts.Puzzles
{
    public interface IPuzzleButton
    {
        public Animator Anim { get; set; }
        public Animator BarrierAnim { get; set; }
        public LayerMask Layer { get; set; }
        
        /// <summary>
        /// Function called when BUTTON is PRESSED. 
        /// </summary>
        /// <param name="Anim"> Button Animator</param>
        /// <param name="BarrierAnim">Barrier (obstacle) Animator</param>
        public void OnPressed(Animator Anim,Animator BarrierAnim);
        /// <summary>
        /// Function called when Button is NOT PRESSED
        /// </summary>
        /// <param name="Anim"> Button Animator</param>
        /// <param name="BarrierAnim">Barrier (obstacle) Animator</param>
        public void OnExit(Animator Anim,Animator BarrierAnim);
     
    }
}