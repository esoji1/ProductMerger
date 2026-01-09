using System.Collections.Generic;
using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.GameFeatures.Merger.ProductMerger
{
    public class ProductFactory
    {
        private MergerManager _mergerManager;
        private List<ProductConfig> _products;

        public ProductFactory(MergerManager mergerManager, List<ProductConfig> products)
        {
            _mergerManager = mergerManager;
            _products = products;
        }

        public ProductConfig Get(ProductsType type, Vector2 position)
        {
            ProductConfig productConfig = GetProduct(type);
            GameObject gameObject = Object.Instantiate(productConfig.Prefab, position, Quaternion.identity, null);
            
            if (gameObject.TryGetComponent(out ProductMerge merge))
                merge.Construct(_mergerManager, this);

            return productConfig;
        }

        private ProductConfig GetProduct(ProductsType type)
        {
            foreach (ProductConfig product in _products)
                if (product.Type == type)
                    return product;

            return null;
        }
    }
}