using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.GameFeatures.Merger.SpawnerMerger
{
    public class SpawnerType : MonoBehaviour
    {
        [SerializeField] private SpawnerConfig spawnerConfig;
 
        public SpawnerConfig SpawnerConfig => spawnerConfig;
    }
}