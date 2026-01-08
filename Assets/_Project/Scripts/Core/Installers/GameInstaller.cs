using _Project.GameFeatures.Grid;
using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform _gridTransform;
        [SerializeField] private GridGenerationConfig _gridConfigurationConfig;
        
        public override void InstallBindings()
        {
            BindGridGeneration();
        }

        private void BindGridGeneration()
        {
            Container
                .Bind<GridGenerationConfig>()
                .FromInstance(_gridConfigurationConfig)
                .AsSingle();
            
            Container
                .BindInterfacesTo<GridGeneration>()
                .AsSingle()
                .WithArguments(_gridTransform);
        }
    }
}