using Game.Assets.Scripts.Door;
using Game.Assets.Scripts.Enemies;
using Game.Assets.Scripts.GUI;
using Game.Assets.Scripts.Player.Singleton.Implementations;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Puzzles;
using Game.Assets.Scripts.Puzzles.Singleton.Implementations;
using Game.Assets.Scripts.Puzzles.Singleton.Interfaces;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GameInstaller:MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGUIController>().To<GUIControllerImplementation>().AsSingle();
            Container.Bind<IEnemyLife>().To<EnemyLife>().AsTransient();
            Container.Bind<IGetCoin>().To<GetCoin>().AsSingle();
            Container.Bind<IPlayerLife>().To<PlayerLifeImplementation>().AsSingle();
            Container.Bind<IPlayerAnimator>().To<PlayerAnimatorImplementation>().AsSingle();
            Container.Bind<IPuzzleActivatePlatform>().To<PuzzleActivateImplementation>().AsSingle();
            Container.Bind<IPuzzleButton>().To<PuzzleButtonImplementation>().AsTransient();
            Container.Bind<IDoor>().To<DoorImplementation>().AsTransient();
            Container.Bind<IPlayerFail>().To<PlayerFailImplementation>().AsTransient();
           
        }
    }
}