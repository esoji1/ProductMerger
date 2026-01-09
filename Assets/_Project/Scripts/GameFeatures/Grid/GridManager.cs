using System.Collections.Generic;
using Zenject;

namespace _Project.GameFeatures.Grid
{
    public class GridManager : IInitializable
    {
        private List<Cell> _cells;
        
        public IReadOnlyList<Cell> Cells => _cells;
        
        public void Initialize() =>
            _cells = new List<Cell>();
        
        public void AddCell(Cell cell) =>
            _cells.Add(cell);
    }
}