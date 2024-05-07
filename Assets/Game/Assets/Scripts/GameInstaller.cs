using Game.Assets.Scripts.Enemies;
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
         //    Container.BindInterfacesAndSelfTo<EnemyLife>().AsSingle();
             
        }
    }
}