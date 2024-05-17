using System;
using System.Collections;

namespace Game.Assets.Scripts.GUI
{
    public interface IGUIController
    {
        public void RestartScene();
        public void PlayGame();
        public void ExitGame();
        public IEnumerator DelayAndStartScene(float time, Action function);
    }
}