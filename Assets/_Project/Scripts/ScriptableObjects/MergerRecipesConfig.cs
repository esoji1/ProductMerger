using System.Collections.Generic;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MergerRecipesConfig", menuName = "Configs/MergerRecipesConfig", order = 0)]
    public class MergerRecipesConfig : ScriptableObject
    {
        [field: SerializeField]
        public List<GameFeatures.Merger.ProductMerger.MergeRecipe> ProductRecipes { get; private set; }

        [field: SerializeField]
        public List<GameFeatures.Merger.SpawnerMerger.MergeRecipe> SpawnerMerge { get; private set; }
    }
}