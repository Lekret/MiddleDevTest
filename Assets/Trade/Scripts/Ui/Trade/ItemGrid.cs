using System.Collections.Generic;
using Trade.Scripts.Logic;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public class ItemGrid : MonoBehaviour
    {
        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotContainer;

        private ItemContainer _items;
        private IHoveringItemSlot _hoveringItemSlot;
        private readonly List<ItemSlot> _slots = new List<ItemSlot>();

        public void Init(ItemContainer items, IHoveringItemSlot hoveringItemSlot)
        {
            _items = items;
            _hoveringItemSlot = hoveringItemSlot;
            ConfigureSize(items.Items);
            InitSlots(items.Items);
            _items.Added += AddItem;
            _items.Removed += RemoveItem;
        }

        private void OnDestroy()
        {
            _items.Added -= AddItem;
            _items.Removed -= RemoveItem;
        }
        
        private void ConfigureSize(IReadOnlyCollection<Item> items)
        {
            if (items.Count == _slots.Count)
                return;
            
            if (items.Count > _slots.Count)
            {
                AddNewSlots(items);
            }
            else
            {
                HideExcessiveSlots(items);
            }
        }

        private void AddNewSlots(IReadOnlyCollection<Item> items)
        {
            var slotsToAdd = items.Count - _slots.Count;
            for (var i = 0; i < slotsToAdd; i++)
            {
                var newSlot = Instantiate(_slotPrefab, _slotContainer);
                newSlot.SetEmpty();
                newSlot.PointerDown += OnSlotPointerDown;
                newSlot.PointerUp += OnSlotPointerUp;
                _slots.Add(newSlot);
            }
        }

        private void OnSlotPointerDown(ItemSlot slot)
        {
            if (slot.Item.HasValue)
            {
                _hoveringItemSlot.SetItem(slot.Item.Value);
                slot.HideItem();
            }
        }
        
        private void OnSlotPointerUp(ItemSlot slot)
        {
            slot.ShowItem();
            _hoveringItemSlot.Disable();
        }

        private void HideExcessiveSlots(IReadOnlyCollection<Item> items)
        {
            for (var i = items.Count; i < _slots.Count; i++)
            {
                _slots[i].Disable();
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

        private void RemoveItem(Item item) => _slots[item.Index].SetEmpty();
    }
}