using System.Collections.Generic;
using _Project.GameFeatures.Grid;
using Zenject;

namespace _Project.Core.Services
{
    public class GridService : IInitializable
    {
        private List<Cell> _cells;
        
        public IReadOnlyList<Cell> Cells => _cells;
        
        public void Initialize() =>
            _cells = new List<Cell>();
        
        public void AddCell(Cell cell) =>
            _cells.Add(cell);
    }
}