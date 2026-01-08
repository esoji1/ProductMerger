using System.Collections.Generic;
using _Project.GameFeatures.ProductMerger;
using UnityEngine;

namespace _Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MergerRecipesConfig", menuName = "Configs/MergerRecipesConfig", order = 0)]
    public class MergerRecipesConfig : ScriptableObject
    {
        [field: SerializeField] public List<MergeRecipe> MergeRecipes { get; private set; }
    }
}