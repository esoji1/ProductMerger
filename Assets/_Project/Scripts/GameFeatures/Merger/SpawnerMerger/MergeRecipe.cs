using System;
using _Project.ScriptableObjects;

namespace _Project.GameFeatures.Merger.SpawnerMerger
{
    [Serializable]
    public class MergeRecipe
    {
        public SpawnerConfig Ingredient1;
        public SpawnerConfig Ingredient2;
        public SpawnerConfig ResultItem;
    }
}