using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using _Game.Scripts.Presentation.Roulette.Spawners;
using UnityEngine;

namespace _Game.Scripts.Presentation.Bootstrap
{
    public class UIBootstrapper : MonoBehaviour
    {
        // References to root UI containers
        [Header("Root")]
        [SerializeField] private Transform _zoneSliderPanelRoot;
        [SerializeField] private Transform _itemContainerPanelRoot;
        [SerializeField] private Transform _popupPanelRoot;
    
        // Prefabs for different UI panels
        [Header("Prefabs")]
        [SerializeField] private GameObject panelZoneSlideBarPrefab;
        [SerializeField] private GameObject panelItemContainerPrefab;
        [SerializeField] private GameObject panelPopupPrefab;

        [Header("Roulette Spawner")]
        [SerializeField] private RouletteSpawner _rouletteSpawner;

        public RectTransform ZoneSlideBar { get; private set; }
        public RectTransform ItemContainer { get; private set; }
        public RectTransform Popup { get; private set; }

        [Header("Options")]
        [SerializeField] private bool spawnOnAwake = true;

        // Subscribe to RestartGame event when enabled
        private void OnEnable()
        {
            GlobalBus.Instance.Subscribe<RestartGameEvent>(OnRestartGame);
        }

        // Unsubscribe from RestartGame event when disabled
        private void OnDisable()
        {
            GlobalBus.Instance.Unsubscribe<RestartGameEvent>(OnRestartGame);
        }

        // Automatically spawn UI panels and roulette on Awake if enabled
        private void Awake()
        {
            if (spawnOnAwake) SpawnAll();
        }

        // Handle game restart event by respawning UI
        private void OnRestartGame(RestartGameEvent e)
        {
            SpawnAll();
        }

        // Destroy existing UI panels and respawn them with new instances
        public void SpawnAll()
        {
            if (ZoneSlideBar) DestroyImmediate(ZoneSlideBar.gameObject);
            if (ItemContainer) DestroyImmediate(ItemContainer.gameObject);
            if (Popup)        DestroyImmediate(Popup.gameObject);
            if (_rouletteSpawner != null) _rouletteSpawner.CreateOrReplaceRoulette();

            ZoneSlideBar = SpawnOnce(panelZoneSlideBarPrefab, ZoneSlideBar, "ui_panel_zone_slide_bar", _zoneSliderPanelRoot);
            ItemContainer = SpawnOnce(panelItemContainerPrefab, ItemContainer, "ui_panel_item_container", _itemContainerPanelRoot);
            Popup = SpawnOnce(panelPopupPrefab, Popup, "ui_panel_popup", _popupPanelRoot);

            if (_rouletteSpawner != null)
                _rouletteSpawner.TrySpawnForLevel(1);
        }

        // Instantiate a UI prefab if not already present
        private RectTransform SpawnOnce(GameObject prefab, RectTransform current, string defaultName, Transform root)
        {
            if (prefab == null || root == null)
            {
                Debug.LogWarning("[UIBootstrapper] Missing refs.");
                return current;
            }

            if (current) Destroy(current.gameObject);

            var go = Instantiate(prefab, root);
            go.name = defaultName;

            var rt = go.transform as RectTransform;
            rt.anchoredPosition = Vector2.zero;
            rt.localScale = Vector3.one;
            return rt;
        }
    }
}