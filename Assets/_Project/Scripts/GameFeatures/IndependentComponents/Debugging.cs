using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.IndependentComponents
{
    public class Debugging : MonoBehaviour
    {
        [SerializeField] private GridGenerationConfig _gridGenerationConfig;
        [SerializeField] private Transform _gridTransform;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            DrawGizmosGrid();
        }

        private void DrawGizmosGrid()
        {
            if (_gridGenerationConfig == null && _gridGenerationConfig.CellPrefab == null)
                return;

            Vector2 offset = _gridGenerationConfig.CenterGrid
                ? new Vector2(-(_gridGenerationConfig.Width - 1) * _gridGenerationConfig.CellSize * 0.5f,
                    -(_gridGenerationConfig.Height - 1) * _gridGenerationConfig.CellSize * 0.5f)
                : Vector2.zero;

            Gizmos.color = Color.green;
            for (int x = 0; x < _gridGenerationConfig.Width; x++)
            {
                for (int y = 0; y < _gridGenerationConfig.Height; y++)
                {
                    Vector2 pos = new Vector2(x * _gridGenerationConfig.CellSize, y * _gridGenerationConfig.CellSize)
                                  + offset + (Vector2)_gridTransform.position;
                    Gizmos.DrawWireCube(pos, Vector2.one * _gridGenerationConfig.CellSize * 0.9f);
                }
            }
        }
#endif
    }
}