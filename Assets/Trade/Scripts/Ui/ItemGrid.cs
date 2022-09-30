using System.Collections.Generic;
using Trade.Scripts.Logic;
using UnityEngine;

namespace Trade.Scripts.Ui
{
    public class ItemGrid : MonoBehaviour
    {
        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotContainer;

        private ItemContainer _items;
        private readonly List<ItemSlot> _slots = new List<ItemSlot>();

        public void Init(ItemContainer items)
        {
            _items = items;
            TryAddSlots(items.Items);
            InitSlots(items.Items);
            _items.Added += AddItem;
            _items.Removed += RemoveItem;
        }

        private void OnDestroy()
        {
            _items.Added -= AddItem;
            _items.Removed -= RemoveItem;
        }
        
        private void TryAddSlots(IReadOnlyCollection<Item> items)
        {
            var slotsToAdd = items.Count - _slots.Count;
            while (slotsToAdd > 0)
            {
                var newSlot = Instantiate(_slotPrefab, _slotContainer);
                newSlot.Clear();
                _slots.Add(newSlot);
                slotsToAdd--;
            }
        }

        private void InitSlots(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                _slots[item.Index].SetItem(item);
            }
        }
        
        private void AddItem(Item item) => _slots[item.Index].SetItem(item);

        private void RemoveItem(Item item) => _slots[item.Index].Clear();
    }
}