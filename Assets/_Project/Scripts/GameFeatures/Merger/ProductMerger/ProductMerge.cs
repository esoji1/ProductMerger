using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.Merger.ProductMerger
{
    [RequireComponent(typeof(ProductType))]
    public class ProductMerge : MonoBehaviour
    {
        private MergerManager _mergerManager;
        private ProductFactory _productFactory;

        private ProductType _productType;

        private void Awake() =>
            _productType = GetComponent<ProductType>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            ProductConfig resultProductConfig = null;

            if (gameObject.GetInstanceID() > other.gameObject.GetInstanceID())
                return;

            if (other.TryGetComponent(out ProductType productType))
                resultProductConfig = _mergerManager.TryProductMerge(_productType.ProductConfig, productType.ProductConfig);

            if (resultProductConfig != null)
            {
                Vector2 mergePosition = (transform.position + other.transform.position) / 2f;
                _productFactory.Get(resultProductConfig.Type, mergePosition);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        [Inject]
        public void Construct(MergerManager mergerManager, ProductFactory productFactory)
        {
            _mergerManager = mergerManager;
            _productFactory = productFactory;
        }
    }
}