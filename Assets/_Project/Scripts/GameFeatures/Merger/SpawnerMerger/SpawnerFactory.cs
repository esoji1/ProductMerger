using System.Collections.Generic;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.Merger.ProductMerger;
using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.GameFeatures.Merger.SpawnerMerger
{
    public class SpawnerFactory
    {
        private MergerManager _mergerManager;
        private List<SpawnerConfig> _spawners;
        private GridManager _gridManager;
        private InputController _inputController;
        private ProductFactory _productFactory;

        public SpawnerFactory(MergerManager mergerManager, List<SpawnerConfig> spawners, GridManager gridManager,
            InputController inputController, ProductFactory productFactory)

        {
            _mergerManager = mergerManager;
            _spawners = spawners;
            _gridManager = gridManager;
            _inputController = inputController;
            _productFactory = productFactory;
        }

        public SpawnerConfig Get(SpawnersType type, Vector2 position)
        {
            SpawnerConfig spawnerConfigConfig = GetSpawner(type);
            GameObject gameObject = Object.Instantiate(spawnerConfigConfig.Prefab, position, Quaternion.identity, null);

            if (gameObject.TryGetComponent(out SpawnerMerge merge))
                merge.Construct(_mergerManager, this);
            else if (gameObject.TryGetComponent(out ProductSpawner.Spawner spawner))
                spawner.Construct(_gridManager, _inputController, _productFactory);

            return spawnerConfigConfig;
        }

        private SpawnerConfig GetSpawner(SpawnersType type)
        {
            foreach (SpawnerConfig spawner in _spawners)
                if (spawner.Type == type)
                    return spawner;

            return null;
        }
    }
}