using System;
using _Project.ScriptableObjects;

namespace _Project.GameFeatures.Merger.ProductMerger
{
    [Serializable]
    public class MergeRecipe
    {
        public ProductConfig Ingredient1;
        public ProductConfig Ingredient2;
        public ProductConfig ResultItem;
    }
}