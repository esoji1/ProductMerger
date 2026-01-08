using _Project.GameFeatures.Grid;
using UnityEngine;

namespace _Project.GameFeatures.DragAndDrop
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private LayerMask _cellLayerMask;

        private Vector3 _initialPosition;
        private Cell _currentCell;

        public void OnDragStart()
        {
            _initialPosition = transform.position;

            _currentCell = GetCellUnderObject();
            _currentCell.ChangeIsCellBusy(false);
        }

        public void OnDragging(Vector3 newPosition) =>
            transform.position = newPosition;

        public void OnDragEnd()
        {
            Cell targetCell = GetCellUnderObject();

            if (targetCell != null && targetCell.IsCellBusy == false)
            {
                transform.position = targetCell.transform.position;
                targetCell.ChangeIsCellBusy(true);

                if (_currentCell != null && _currentCell != targetCell)
                    _currentCell.ChangeIsCellBusy(false);
            }
            else
            {
                transform.position = _initialPosition;

                if (_currentCell != null)
                    _currentCell.ChangeIsCellBusy(true);
            }
        }

        private Cell GetCellUnderObject()
        {
            Vector2 worldPos = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, 0.1f, _cellLayerMask);

            if (hit.collider != null && hit.collider.TryGetComponent(out Cell cell))
                return cell;

            return null;
        }
    }
}