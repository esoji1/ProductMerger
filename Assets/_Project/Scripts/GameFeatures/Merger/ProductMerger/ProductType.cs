using _Project.ScriptableObjects;
using UnityEngine;
 
 namespace _Project.GameFeatures.Merger.ProductMerger
 {
     public class ProductType : MonoBehaviour
     {
         [SerializeField] private ProductConfig productConfig;
 
         public ProductConfig ProductConfig => productConfig;
     }
 }