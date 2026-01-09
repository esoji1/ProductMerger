using _Project.GameFeatures.Merger.ProductMerger;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Product", menuName = "Configs/Product", order = 0)]
    public class ProductConfig : ScriptableObject
    {
        [field: SerializeField] public ProductsType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}