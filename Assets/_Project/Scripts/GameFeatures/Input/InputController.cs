using System;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.GameFeatures.Input
{
    public class InputController : IInitializable, IDisposable
    {
        private InputAction _clickAction;
        private InputAction _positionAction;

        public InputController(PlayerInput playerInput)
        {
            _clickAction = playerInput.actions["Click"];
            _positionAction = playerInput.actions["Position"];
        }
        
        public InputAction ClickAction =>  _clickAction;
        public InputAction PositionAction =>  _positionAction;
        
        public void Initialize()
        {
            _clickAction?.Enable();
            _positionAction?.Enable();
        }

        public void Dispose()
        {
            _clickAction?.Disable();
            _positionAction?.Disable();

            _clickAction?.Dispose();
            _positionAction?.Dispose();
        }
    }
}