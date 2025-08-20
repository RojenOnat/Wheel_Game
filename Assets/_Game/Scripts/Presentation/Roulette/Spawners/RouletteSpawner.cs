using System.Collections.Generic;
using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Config;
using _Game.Scripts.Infrastructure.Messaging;
using _Game.Scripts.Presentation.Roulette.Views;
using UnityEngine;

namespace _Game.Scripts.Presentation.Roulette.Spawners
{
    public class RouletteSpawner : MonoBehaviour
    {
        [Header("Data")]
        public List<RouletteTypeSO> RouletteList;

        public ZoneLevelConfigSO ZoneLevelConfigData;

        [Header("Prefab")]
        [SerializeField] private GameObject _roulettePrefab;

        [Header("Transform")]
        [SerializeField] private Transform _mainCanvasTransform;

        private GameObject _currentRoulette;
        private int _currentSpawnedIndex = -1; // Index of the currently spawned roulette
        private int _roulletteIndex = 0;       // Target index to be instantiated
    
    
        private void OnEnable()
        {
            GlobalBus.Instance.Subscribe<ZoneLevelChangedEvent>(OnZoneLevelChanged);
        }

        private void OnDisable()
        {
            GlobalBus.Instance.Unsubscribe<ZoneLevelChangedEvent>(OnZoneLevelChanged);
        }


        private void OnZoneLevelChanged(ZoneLevelChangedEvent e)
        {
            //Debug.LogError(e.Level);
            TrySpawnForLevel(e.Level);
        }

        public void TrySpawnForLevel(int level)
        {
            int desired = ComputeIndex(level);              // 0 | 1 | 2
            if (desired == _currentSpawnedIndex) return;    // Do nothing if the desired roulette is already spawned

            _roulletteIndex = desired;
            CreateOrReplaceRoulette();
        }

        // Rule: Gold → 2, Silver → 1, Others → 0
        private int ComputeIndex(int level)
        {
        
            if (level == ZoneLevelConfigData.GoldRouletteLevel) return 2;
            if (level == ZoneLevelConfigData.SilverRouletteLevel) return 1;
            return 0;
        }

        public void CreateOrReplaceRoulette()
        {
            if (_currentRoulette != null)
                Destroy(_currentRoulette);
        
            _currentRoulette = Instantiate(_roulettePrefab, _mainCanvasTransform);
            _currentRoulette.name = RouletteList[_roulletteIndex].TypeData.DisplayName;

            var rouletteMono = _currentRoulette.GetComponent<RouletteMono>();
            rouletteMono.Bind(RouletteList[_roulletteIndex]);
            rouletteMono.InitializeSpawner();

            _currentSpawnedIndex = _roulletteIndex;
        }
    }
}