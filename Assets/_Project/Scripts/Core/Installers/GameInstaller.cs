using System.Collections.Generic;
using _Project.GameFeatures.DragAndDrop;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.Merger;
using _Project.GameFeatures.Merger.ProductMerger;
using _Project.GameFeatures.Merger.SpawnerMerger;
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
        [SerializeField] private MergerRecipesConfig _mergerRecipesConfig;
        [SerializeField] private List<ProductConfig> _products;
        [SerializeField] private List<SpawnerConfig> _spawners;

        public override void InstallBindings()
        {
            BindGridGeneration();
            BindInputController();
            BindDrag();
            BindProductMerger();
            BindSpawnerMerger();
        }

        private void BindGridGeneration()
        {
            Container
                .Bind<GridGenerationConfig>()
                .FromInstance(_gridConfigurationConfig)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GridManager>()
                .AsSingle();

            Container
                .BindInterfacesTo<GridGeneration>()
                .AsSingle()
                .WithArguments(_gridTransform);
        }

        private void BindInputController()
        {
            Container
                .BindInterfacesAndSelfTo<InputController>()
                .AsSingle()
                .WithArguments(_playerInput);
        }

        private void BindDrag()
        {
            Container
                .BindInterfacesTo<Drag>()
                .AsSingle();
        }

        private void BindProductMerger()
        {
            Container
                .Bind<MergerRecipesConfig>()
                .FromInstance(_mergerRecipesConfig)
                .AsSingle();

            Container
                .Bind<MergerManager>()
                .AsSingle();

            Container
                .Bind<List<ProductConfig>>()
                .FromInstance(_products)
                .AsSingle();

            Container
                .Bind<ProductFactory>()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindSpawnerMerger()
        {
            Container
                .Bind<List<SpawnerConfig>>()
                .FromInstance(_spawners)
                .AsSingle();
            
            Container
                .Bind<SpawnerFactory>()
                .AsSingle();
        }
    }
}