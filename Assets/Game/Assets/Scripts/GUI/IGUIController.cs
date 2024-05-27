using System;
using System.Collections;
using Platformer.Assets.Game.Scripts.Player.UseCases.Controller;

namespace Game.Assets.Scripts.GUI
{
    public interface IGUIController
    {
        public void IntroMenu();
        public void RestartScene();
        public void PlayGame();
        public void ExitGame();
        public IEnumerator DelayAndStartScene(float time, Action function);
    }
}