using _Project.ScriptableObjects;
using UnityEngine;

namespace _Project.GameFeatures.ProductMerger
{
    public class ProductManager
    {
        private MergerRecipesConfig _mergerRecipesConfig;

        public ProductManager(MergerRecipesConfig mergerRecipesConfig) =>
            _mergerRecipesConfig = mergerRecipesConfig;

        public Product TryMerge(Product productA, Product productB)
        {
            foreach (MergeRecipe recipe in _mergerRecipesConfig.MergeRecipes)
            {
                bool match = (recipe.Ingredient1 == productA && recipe.Ingredient2 == productB) ||
                             (recipe.Ingredient1 == productB && recipe.Ingredient2 == productA);

                if (match)
                    return recipe.ResultItem;
            }

            return null;
        }
    }
}