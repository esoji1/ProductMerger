using System.Collections.Generic;
using _Project.GameFeatures.DragAndDrop;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.ProductMerger;
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
        [SerializeField]   private List<Product> _products;
        
        public override void InstallBindings()
        {
            BindGridGeneration();
            BindInputController();  
            BindDrag();
            ProductMerger();
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

        private void ProductMerger()
        {
            Container
                .Bind<MergerRecipesConfig>()
                .FromInstance(_mergerRecipesConfig)
                .AsSingle();
            
            Container
                .Bind<ProductManager>()
                .AsSingle();

            Container
                .Bind<List<Product>>()
                .FromInstance(_products)
                .AsSingle();
            
            Container
                .Bind<ProductFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}