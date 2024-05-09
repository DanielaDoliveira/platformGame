using Game.Assets.Scripts.Enemies;
using Game.Assets.Scripts.Player.Singleton.Implementations;
using Game.Assets.Scripts.Player.Singleton.Interfaces;
using Game.Assets.Scripts.Puzzles;
using Platformer.Assets.Game.Scripts.Player.Singleton;
using Platformer.Assets.Game.Scripts.Player.UseCases;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GameInstaller:MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyLife>().To<EnemyLife>().AsTransient();
            Container.Bind<IGetCoin>().To<GetCoin>().AsSingle();
            Container.Bind<IPlayerLife>().To<PlayerLifeImplementation>().AsSingle();
            Container.Bind<IPuzzleButton>().To<PuzzleButtonImplementation>().AsTransient();
         //    Container.BindInterfacesAndSelfTo<EnemyLife>().AsSingle();
             
        }
    }
}