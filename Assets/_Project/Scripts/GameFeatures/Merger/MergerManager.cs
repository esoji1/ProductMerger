using _Project.ScriptableObjects;

namespace _Project.GameFeatures.Merger
{   
    public class MergerManager
    {
        private MergerRecipesConfig _mergerRecipesConfig;

        public MergerManager(MergerRecipesConfig mergerRecipesConfig) =>
            _mergerRecipesConfig = mergerRecipesConfig;

        public ProductConfig TryProductMerge(ProductConfig productConfigA, ProductConfig productConfigB)
        {
            foreach (ProductMerger.MergeRecipe recipe in _mergerRecipesConfig.ProductRecipes)
            {
                bool match = (recipe.Ingredient1 == productConfigA && recipe.Ingredient2 == productConfigB) ||
                             (recipe.Ingredient1 == productConfigB && recipe.Ingredient2 == productConfigA);

                if (match)
                    return recipe.ResultItem;
            }

            return null;
        }
        
        public SpawnerConfig TrySpawnerMergee(SpawnerConfig spawnerConfigA, SpawnerConfig spawnerConfigB)
        {
            foreach (SpawnerMerger.MergeRecipe recipe in _mergerRecipesConfig.SpawnerMerge)
            {
                bool match = (recipe.Ingredient1 == spawnerConfigA && recipe.Ingredient2 == spawnerConfigB) ||
                             (recipe.Ingredient1 == spawnerConfigB && recipe.Ingredient2 == spawnerConfigA);

                if (match)
                    return recipe.ResultItem;
            }

            return null;
        }
    }
}