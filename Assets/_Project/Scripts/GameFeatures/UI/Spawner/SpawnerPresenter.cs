using System;
using System.Collections.Generic;
using System.Threading;
using _Project.GameFeatures.Grid;
using _Project.GameFeatures.Merger.SpawnerMerger;
using Cysharp.Threading.Tasks;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.GameFeatures.UI.Spawner
{
    public class SpawnerPresenter : IInitializable, IDisposable
    {
        private readonly SpawnerFactory _spawnerFactory;
        private readonly SpawnerView _spawnerView;
        private readonly GridManager _gridManager;

        private CancellationTokenSource _autoSpawnCts;
        private bool _isSpawningInProgress;

        public SpawnerPresenter(SpawnerFactory spawnerFactory, SpawnerView spawnerView, GridManager gridManager)
        {
            _spawnerFactory = spawnerFactory;
            _spawnerView = spawnerView;
            _gridManager = gridManager;
        }

        public void Initialize() =>
            _spawnerView.OnSpawnClick += OnSpawnClick;

        public void Dispose()
        {
            _spawnerView.OnSpawnClick -= OnSpawnClick;
            StopAutoSpawn();
        }

        private void OnSpawnClick()
        {
            if (_isSpawningInProgress)
                return;

            StartAutoSpawn();
        }

        private void StartAutoSpawn()
        {
            _isSpawningInProgress = true;
            _autoSpawnCts = new CancellationTokenSource();

            _spawnerView.SetAutoSpawnState(true);

            AutoSpawnCycle(_autoSpawnCts.Token).Forget();
        }

        private void StopAutoSpawn()
        {
            _autoSpawnCts?.Cancel();
            _autoSpawnCts?.Dispose();
            _autoSpawnCts = null;

            _isSpawningInProgress = false;
            _spawnerView.SetAutoSpawnState(false);
        }

        private async UniTask AutoSpawnCycle(CancellationToken cancellationToken)
        {
            try
            {
                Cell freeCell = GetRandomFreeCell();
                _spawnerFactory.Get(SpawnersType.Spawner1, freeCell.transform.position);

                await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    return;

                await UniTask.SwitchToMainThread();
            }
            finally
            {
                StopAutoSpawn();
            }
        }

        private Cell GetRandomFreeCell()
        {
            IReadOnlyList<Cell> cells = _gridManager.Cells;
            int count = cells.Count;

            if (count == 0)
                return null;

            List<int> freeIndices = new(count);

            for (int i = 0; i < count; i++)
                if (cells[i].IsCellBusy == false)
                    freeIndices.Add(i);

            if (freeIndices.Count == 0)
                return null;

            int randomIndex = freeIndices[Random.Range(0, freeIndices.Count)];
            return cells[randomIndex];
        }
    }
}