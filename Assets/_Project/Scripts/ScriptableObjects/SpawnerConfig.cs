using _Project.GameFeatures.Merger.SpawnerMerger;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner", menuName = "Configs/Spawner", order = 0)]
    public class SpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public SpawnersType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}