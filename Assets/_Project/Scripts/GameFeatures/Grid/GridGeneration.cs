using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Grid
{
    public class GridGeneration : IInitializable
    {
        private GridGenerationConfig _gridGenerationConfig;
        private Transform _gridTransform;
        private GridManager _gridManager;

        public GridGeneration(GridGenerationConfig gridGenerationConfig, Transform gridTransform,
            GridManager gridManager)
        {
            _gridGenerationConfig = gridGenerationConfig;
            _gridTransform = gridTransform;
            _gridManager  = gridManager;
        }

        public void Initialize() =>
            GenerateGrid();

        private void GenerateGrid()
        {
            Vector2 offset = _gridGenerationConfig.CenterGrid
                ? new Vector2(-(_gridGenerationConfig.Width - 1) * _gridGenerationConfig.CellSize * 0.5f,
                    -(_gridGenerationConfig.Height - 1) * _gridGenerationConfig.CellSize * 0.5f)
                : Vector2.zero;

            int cellIndex = 0;

            for (int i = 0; i < _gridGenerationConfig.Width; i++)
            {
                for (int j = 0; j < _gridGenerationConfig.Height; j++)
                {
                    Vector2 position =
                        new Vector2(i * _gridGenerationConfig.CellSize, j * _gridGenerationConfig.CellSize) + offset;

                    Cell cell = Object.Instantiate(_gridGenerationConfig.CellPrefab, position, Quaternion.identity,
                        _gridTransform);
                    _gridManager.AddCell(cell);
                    cell.name = $"Cell ({cellIndex})";
                    cellIndex++;
                }
            }
        }
    }
}