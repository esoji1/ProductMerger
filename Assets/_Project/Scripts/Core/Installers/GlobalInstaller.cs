using _Project.IndependentComponents;
using Zenject;

namespace _Project.Core.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLayers();
        }

        private void BindLayers()
        {
            Container
                .BindInterfacesAndSelfTo<Layers>()
                .AsSingle();
        }
    }
}