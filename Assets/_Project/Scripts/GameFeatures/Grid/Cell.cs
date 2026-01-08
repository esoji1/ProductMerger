using UnityEngine;

namespace _Project.GameFeatures.Grid
{
    public class Cell : MonoBehaviour
    {
        private bool _isCellBusy;

        public bool IsCellBusy => _isCellBusy;

        public void ChangeIsCellBusy(bool isCellBusy) => 
            _isCellBusy = isCellBusy;
    }
}