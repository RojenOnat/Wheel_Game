using System.Collections.Generic;
using _Game.Scripts.Application.Events;
using _Game.Scripts.Infrastructure.Messaging;
using UnityEngine;

namespace _Game.Scripts.Presentation.UI.Containers
{
    public class ItemContainerMono : MonoBehaviour
    {
        [Header("Root & Prefab")]
        [SerializeField] private RectTransform _root;
        [SerializeField] private ItemSlotUI _slotPrefab;

        // Dictionary mapping item ID to UI slot
        private readonly Dictionary<string, ItemSlotUI> _slotsById = new();

        private void OnEnable()
        {
            GlobalBus.Instance.Subscribe<RouletteItemDataEvent>(OnItemReceived);
        }

        private void OnDisable()
        {
            GlobalBus.Instance.Unsubscribe<RouletteItemDataEvent>(OnItemReceived);
        }

        private void OnItemReceived(RouletteItemDataEvent e)
        {
            if (e.Count == 0) return;

            if (_slotsById.TryGetValue(e.Id, out var slot))
            {
                // Existing item: increase count
                slot.AddCount(e.Count);

                // Update icon if necessary
                if (e.Icon && slot.Icon != e.Icon)
                    slot.SetIcon(e.Icon);

                if (slot.Count <= 0)
                    RemoveSlot(e.Id);
            }
            else
            {
                if (e.Count < 0) return; // Do not create a new slot with a negative count

                // New item: create and initialize slot
                var newSlot = Instantiate(_slotPrefab, _root);
                newSlot.Initialize(e.Id, e.Icon, e.Count);
                _slotsById[e.Id] = newSlot;
            }
        }

        public void RemoveSlot(string id)
        {
            if (_slotsById.TryGetValue(id, out var slot) && slot)
            {
                _slotsById.Remove(id);
                Destroy(slot.gameObject);
            }
        }

        public void ClearAll()
        {
            foreach (var kv in _slotsById)
                if (kv.Value) Destroy(kv.Value.gameObject);
            _slotsById.Clear();
        }
    }
}