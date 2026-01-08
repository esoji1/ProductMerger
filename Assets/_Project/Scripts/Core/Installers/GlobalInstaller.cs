using _Project.Core.Services;
using _Project.IndependentComponents;
using Zenject;

namespace _Project.Core.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLayers();
            BindGridService();
        }

        private void BindLayers()
        {
            Container
                .BindInterfacesAndSelfTo<Layers>()
                .AsSingle();
        }

        private void BindGridService()
        {
            Container
                .BindInterfacesAndSelfTo<GridService>()
                .AsSingle();
        }
    }
}