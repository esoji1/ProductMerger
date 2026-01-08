using _Project.GameFeatures.DragAndDrop;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform _gridTransform;
        [SerializeField] private GridGenerationConfig _gridConfigurationConfig;
        [SerializeField] private PlayerInput _playerInput;
        
        public override void InstallBindings()
        {
            BindGridGeneration();
            BindInputController();  
            BindDrag();
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

        private void BindInputController()
        {
            Container
                .Bind<InputController>()
                .AsSingle()
                .WithArguments(_playerInput);
        }

        private void BindDrag()
        {
            Container
                .BindInterfacesTo<Drag>()
                .AsSingle();
        }
    }
}