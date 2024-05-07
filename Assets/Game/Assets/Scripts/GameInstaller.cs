using Game.Assets.Scripts.Enemies;
using Zenject;

namespace Game.Assets.Scripts
{
    public class GameInstaller:MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
         //   Container.Bind<IEnemyLife>().To<EnemyLife>().AsSingle();
             Container.BindInterfacesAndSelfTo<EnemyLife>().AsSingle();

        }
    }
}