using System;
using _Project.GameFeatures.Input;
using _Project.IndependentComponents;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.GameFeatures.DragAndDrop
{
    public class Drag : IInitializable, IDisposable
    {
        private InputController _inputController;
        private Camera _mainCamera;
        private Layers _layers;

        private LayerMask _draggableLayerMask;
        private Draggable _currentDraggable;
        private Vector3 _offset;
        private IInitializable _initializableImplementation;

        public Drag(InputController inputController, Layers layers)
        {
            _inputController = inputController;
            _layers = layers;
        }

        public void Initialize()
        {
            _draggableLayerMask = _layers.DraggableLayer;
            _mainCamera = Camera.main;
            
            _inputController.ClickAction.started += OnClickStarted;
            _inputController.ClickAction.canceled += OnClickCanceled;
            _inputController.PositionAction.performed += OnPositionPerformed;
        }

        public void Dispose()
        {
            _inputController.ClickAction.started -= OnClickStarted;
            _inputController.ClickAction.canceled -= OnClickCanceled;
            _inputController.PositionAction.performed -= OnPositionPerformed;
        }

        private void OnClickStarted(InputAction.CallbackContext ctx)
        {
            Vector2 screenPos = _inputController.PositionAction.ReadValue<Vector2>();

            Ray ray = _mainCamera.ScreenPointToRay(screenPos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _draggableLayerMask);

            if (hit.collider != null && hit.collider.TryGetComponent(out Draggable draggable))
            {
                _currentDraggable = draggable;
                _currentDraggable.OnDragStart();
            }
        }

        private void OnPositionPerformed(InputAction.CallbackContext ctx)
        {
            if (_currentDraggable == null)
                return;

            Vector2 screenPos = ctx.ReadValue<Vector2>();
            Vector3 worldPos = _mainCamera
                .ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, -_mainCamera.transform.position.z));
            Vector3 newPos = worldPos + _offset;
            newPos.z = _currentDraggable.transform.position.z;

            _currentDraggable.OnDragging(newPos);
        }

        private void OnClickCanceled(InputAction.CallbackContext ctx)
        {
            if (_currentDraggable == null)
                return;

            _currentDraggable.OnDragEnd();
            _currentDraggable = null;
        }
    }
}