using System;
using System.Collections.Generic;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Input;
using _Project.GameFeatures.ProductMerger;
using _Project.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.GameFeatures.ProductSpawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Product _product1;
        [SerializeField] private Product _product2;
        [SerializeField] private float _percentageProductLoss1;
        [SerializeField] private float _percentageProductLoss2;
        [SerializeField] private LayerMask _layerMask;

        [Inject] private GridManager _gridManager;
        [Inject] private InputController _inputController;
        [Inject] private ProductFactory _productFactory;

        private Camera _mainCamera;

        private void Start() =>
            _mainCamera = Camera.main;

        private void OnEnable() =>
            _inputController.ClickAction.started += OnClickStarted;

        private void OnDisable() =>
            _inputController.ClickAction.started -= OnClickStarted;

        private void OnClickStarted(InputAction.CallbackContext ctx)
        {
            Vector2 screenPos = _inputController.PositionAction.ReadValue<Vector2>();
            Ray ray = _mainCamera.ScreenPointToRay(screenPos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _layerMask);

            if (hit.collider == null || !hit.collider.TryGetComponent<Spawner>(out _))
                return;

            Cell freeCell = GetRandomFreeCell();

            if (freeCell == null)
                return;

            float randomValue = Random.value;

            if (randomValue < _percentageProductLoss1)
                _productFactory.Get(_product1.Type, freeCell.transform.position);
            else if (randomValue < _percentageProductLoss1 + _percentageProductLoss2)
                _productFactory.Get(_product2.Type, freeCell.transform.position);
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