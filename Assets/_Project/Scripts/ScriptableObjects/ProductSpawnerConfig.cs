using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ProductSpawnerConfig", menuName = "Configs/ProductSpawnerConfig", order = 0)]
    public class ProductSpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public ProductConfig Product1 { get; private set; }
        [field: SerializeField] public ProductConfig Product2 { get; private set; }
        [field: SerializeField] public float PercentageProductLoss1 { get; private set; }
        [field: SerializeField] public float PercentageProductLoss2 { get; private set; }
        [field: SerializeField] public LayerMask SpawnerLayerMack { get; private set; }
    }
}