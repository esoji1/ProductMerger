using _Project.GameFeatures.Grid;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GridGenerationConfig", menuName = "Configs/GridGenerationConfig", order = 0)]
    public class GridGenerationConfig : ScriptableObject
    {
        [field: SerializeField] public Cell CellPrefab { get; private set; }
        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
        [field: SerializeField] public float CellSize { get; private set; }
        [field: SerializeField] public bool CenterGrid { get; private set; }
    }
}