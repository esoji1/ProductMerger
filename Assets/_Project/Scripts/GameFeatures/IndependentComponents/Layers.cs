using UnityEngine;
using Zenject;

namespace _Project.IndependentComponents
{
    public class Layers : IInitializable
    {
        private LayerMask _draggableLayer;
        private LayerMask _cellLayer;

        public LayerMask DraggableLayer => _draggableLayer;
        public LayerMask CellLayer => _cellLayer;

        public void Initialize()
        {
            _draggableLayer = LayerMask.GetMask("Draggable");
            _cellLayer = LayerMask.GetMask("Cell");
        }

        public static LayerMask FromLayer(int layer) =>
            LayerMask.GetMask(LayerMask.LayerToName(layer));

        public static LayerMask Multiple(params string[] layerNames) =>
            LayerMask.GetMask(layerNames);
    }
}