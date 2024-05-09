using System;
using UnityEngine;

namespace Game.Assets.Scripts.Puzzles
{
    public class PuzzleButtonImplementation:IPuzzleButton
    {
        
        public Animator Anim { get; set; }
        public Animator BarrierAnim { get; set; }
        public LayerMask Layer { get; set; }
      
   

    
        public void OnPressed( Animator Anim,Animator BarrierAnim)
        {
            var isButtonPressed = true;
            var isBarrierDown = true;
            Anim.SetBool("isPressed",isButtonPressed);
            BarrierAnim.SetBool("isPressed",isBarrierDown);
        }

        public void OnExit(Animator Anim,Animator BarrierAnim)
        {
            var isButtonPressed = false;
            var isBarrierDown = false;
            Anim.SetBool("isPressed",isButtonPressed);
            BarrierAnim.SetBool("isPressed",isBarrierDown);
        }

        

       
    }
}