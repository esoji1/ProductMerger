using _Project.ScriptableObjects;
using UnityEngine;
 
 namespace _Project.GameFeatures.ProductMerger
 {
     public class ProductType : MonoBehaviour
     {
         [SerializeField] private Product _product;
 
         public Product Product => _product;
     }
 }