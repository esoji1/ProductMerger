using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.GameFeatures.UI.Spawner
{
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField] private Button _spawnButton;
        
        private Image _spawnerImage;
        
        public event UnityAction OnSpawnClick
        {
            add { _spawnButton.onClick.AddListener(value); }
            remove { _spawnButton.onClick.RemoveListener(value); }
        }

        private void Start() =>
            _spawnerImage = _spawnButton.GetComponent<Image>();

        public void SetAutoSpawnState(bool state) =>
            _spawnerImage.color = state ? Color.red : Color.green;
    }
}