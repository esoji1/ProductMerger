using UnityEngine.InputSystem;

namespace _Project.GameFeatures.Input
{
    public class InputController
    {
        private InputAction _clickAction;
        private InputAction _positionAction;
        
        public InputAction ClickAction =>  _clickAction;
        public InputAction PositionAction =>  _positionAction;

        public InputController(PlayerInput playerInput)
        {
            _clickAction = playerInput.actions["Click"];
            _positionAction = playerInput.actions["Position"];
        }
    }
}