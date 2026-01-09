using System.Collections.Generic;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.Merger.ProductMerger;
using _Project.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.GameFeatures.ProductSpawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ProductSpawnerConfig _productSpawnerConfig;

        private GridManager _gridManager;
        private InputController _inputController;
        private ProductFactory _productFactory;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            _inputController.ClickAction.started += OnClickStarted;
        }

        private void OnDestroy() =>
            _inputController.ClickAction.started -= OnClickStarted;

        [Inject]
        public void Construct(GridManager gridManager, InputController inputController, ProductFactory productFactory)
        {
            _gridManager = gridManager;
            _inputController = inputController;
            _productFactory = productFactory;
        }

        private void OnClickStarted(InputAction.CallbackContext ctx)
        {
            Vector2 screenPos = _inputController.PositionAction.ReadValue<Vector2>();
            Ray ray = _mainCamera.ScreenPointToRay(screenPos);
            RaycastHit2D hit =
                Physics2D.GetRayIntersection(ray, Mathf.Infinity, _productSpawnerConfig.SpawnerLayerMack);

            if (hit.collider == null ||
                hit.collider.TryGetComponent(out Spawner spawner) == false ||
                spawner != this)
                return;

            Cell freeCell = GetRandomFreeCell();

            if (freeCell == null)
                return;

            float randomValue = Random.value;

            if (randomValue < _productSpawnerConfig.PercentageProductLoss1)
                _productFactory.Get(_productSpawnerConfig.Product1.Type, freeCell.transform.position);
            else if (randomValue < _productSpawnerConfig.PercentageProductLoss1 +
                     _productSpawnerConfig.PercentageProductLoss2)
                _productFactory.Get(_productSpawnerConfig.Product2.Type, freeCell.transform.position);
        }

        private Cell GetRandomFreeCell()
        {
            IReadOnlyList<Cell> cells = _gridManager.Cells;
            int count = cells.Count;

            if (count == 0)
                return null;

            List<int> freeIndices = new(count);

            for (int i = 0; i < count; i++)
                if (cells[i].IsCellBusy == false)
                    freeIndices.Add(i);

            if (freeIndices.Count == 0)
                return null;

            int randomIndex = freeIndices[Random.Range(0, freeIndices.Count)];
            return cells[randomIndex];
        }
    }
}