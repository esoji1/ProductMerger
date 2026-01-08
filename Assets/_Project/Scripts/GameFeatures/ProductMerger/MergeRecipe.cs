using System;
using _Project.ScriptableObjects;

namespace _Project.GameFeatures.ProductMerger
{
    [Serializable]
    public class MergeRecipe
    {
        public Product Ingredient1;
        public Product Ingredient2;
        public Product ResultItem;
    }
}