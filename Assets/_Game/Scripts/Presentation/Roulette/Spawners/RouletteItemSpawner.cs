using System.Collections.Generic;
using _Game.Scripts.Application.Events;
using _Game.Scripts.Application.Factories;
using _Game.Scripts.Infrastructure.Config;
using _Game.Scripts.Infrastructure.Messaging;
using _Game.Scripts.Presentation.Roulette.Views;
using UnityEngine;

namespace _Game.Scripts.Presentation.Roulette.Spawners
{
    public class RouletteItemSpawner : MonoBehaviour
    {
        [Header("Prefabs/Refs")]
        [SerializeField] private GameObject _itemPrefab;

        [Header("Layout")]
        [SerializeField] private float _radius = 500f;
        [SerializeField] private float _startAngleDeg = -90f;
        [SerializeField] private bool _clockwise = true;

        [Header("Transform")] [SerializeField] public Transform _rootTransform;

        [Header("List Of Item Objects")]
        public List<WheelItemMono> CreatedWheelItemMonoList ;
    
        private void OnEnable()
        {
            // Subscribe to spin stopped event
            GlobalBus.Instance.Subscribe<RouletteSpinStoppedEvent>(OnSpinStopped);
        }
        private void OnDisable()
        {
            // Unsubscribe from spin stopped event
            GlobalBus.Instance.Unsubscribe<RouletteSpinStoppedEvent>(OnSpinStopped);
        }
        private void OnSpinStopped(RouletteSpinStoppedEvent e)
        {
            int idx = e.RouletteSpinValue;
            var item = CreatedWheelItemMonoList[idx];
            if (item == null)
            {
                Debug.LogWarning($"[RouletteItemSpawner] Index {idx} null.");
                return;
            }

            var icon = item.GetIcon;
            var name = item.GetName;
            var count = item.GetReward;
            var id = item.GetId;

            // Notify UI to open a popup with the selected item
            GlobalBus.Instance.Publish(new ShowCardPopupEvent(icon, name,count,id));
        }
        public void Clear()
        {
            for (int i = _rootTransform.childCount - 1; i >= 0; i--)
                DestroyImmediate(_rootTransform.GetChild(i).gameObject);
        }

        public void SpawnItems(RouletteTypeSO db)
        {
            if (db.RouletteItemList.Count == 0)
            {
                Debug.LogError("Roulette Item List Is Null!");
                return;
            }

            int count = db.RouletteItemList.Count;
            float step = 360f / count;
            float dir  = _clockwise ? -1f : 1f;

            for (int i = 0; i < count; i++)
            {
                var data = db.RouletteItemList[i];
                var view = Instantiate(_itemPrefab, _rootTransform);
                var itemData = WheelItemFactory.Create(db.RouletteItemList[i].Items);
                var wheelItemMono = view.GetComponent<WheelItemMono>();
            
                CreatedWheelItemMonoList.Add(wheelItemMono);
            
            
                view.name = $"Slot_{i}_{itemData.Name}";
                wheelItemMono.BindData(itemData,db.RouletteItemList[i].Items.ItemView);
           

                float angle = 90f + dir * (i * step);
                Vector2 unit = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                var rt = (RectTransform)view.transform;
                rt.anchoredPosition = unit * (_radius - 24f);     
                // Adjust item position to avoid going out of bounds
                rt.localRotation    = Quaternion.Euler(0, 0, angle - 90f);
            }
        }
    }
}
