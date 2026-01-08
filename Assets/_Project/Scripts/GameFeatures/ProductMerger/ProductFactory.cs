using System.Collections.Generic;
using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.GameFeatures.ProductMerger
{
    public class ProductFactory
    {
        private ProductManager _productManager;
        private List<Product> _products;

        public ProductFactory(ProductManager productManager, List<Product> products)
        {
            _productManager = productManager;
            _products = products;
        }

        public Product Get(ProductsType type, Vector2 position)
        {
            Product product = GetProduct(type);
            GameObject gameObject = Object.Instantiate(product.Prefab, position, Quaternion.identity, null);
            
            if (gameObject.TryGetComponent(out Merge merge))
                merge.Construct(_productManager, this);

            return product;
        }

        private Product GetProduct(ProductsType type)
        {
            foreach (Product product in _products)
                if (product.Type == type)
                    return product;

            return null;
        }
    }
}