using _Project.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.ProductMerger
{
    [RequireComponent(typeof(ProductType))]
    public class Merge : MonoBehaviour
    {
        private ProductManager _productManager;
        private ProductFactory _productFactory;

        private ProductType _productType;

        private void Awake() =>
            _productType = GetComponent<ProductType>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            Product resultProduct = null;

            if (gameObject.GetInstanceID() > other.gameObject.GetInstanceID())
                return;

            if (other.TryGetComponent(out ProductType productType))
                resultProduct = _productManager.TryMerge(_productType.Product, productType.Product);

            if (resultProduct != null)
            {
                Vector2 mergePosition = (transform.position + other.transform.position) / 2f;
                _productFactory.Get(resultProduct.Type, mergePosition);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        [Inject]
        public void Construct(ProductManager productManager, ProductFactory productFactory)
        {
            _productManager = productManager;
            _productFactory = productFactory;
        }
    }
}