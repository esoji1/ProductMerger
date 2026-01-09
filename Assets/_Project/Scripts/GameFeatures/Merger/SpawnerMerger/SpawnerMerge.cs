using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Merger.SpawnerMerger
{
    [RequireComponent(typeof(SpawnerType))]
    public class SpawnerMerge : MonoBehaviour
    {
        private MergerManager _mergerManager;
        private SpawnerFactory _spawnerFactory;

        private SpawnerType _spawnerType;

        private void Awake() =>
            _spawnerType = GetComponent<SpawnerType>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            SpawnerConfig resultSpawnerConfig = null;

            if (gameObject.GetInstanceID() > other.gameObject.GetInstanceID())
                return;

            if (other.TryGetComponent(out SpawnerType spawnerType))
                resultSpawnerConfig = _mergerManager.TrySpawnerMergee(_spawnerType.SpawnerConfig, spawnerType.SpawnerConfig);

            if (resultSpawnerConfig != null)
            {
                Vector2 mergePosition = (transform.position + other.transform.position) / 2f;
                _spawnerFactory.Get(resultSpawnerConfig.Type, mergePosition);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        [Inject]
        public void Construct(MergerManager mergerManager, SpawnerFactory spawnerFactory)
        {
            _mergerManager = mergerManager;
            _spawnerFactory = spawnerFactory;
        }
    }
}