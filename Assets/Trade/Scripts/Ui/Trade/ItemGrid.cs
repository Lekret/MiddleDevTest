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
            ConfigureSize();
            InitSlots(items.Items);
            _items.Added += AddItem;
            _items.Removed += RemoveItem;
        }

        private void OnDestroy()
        {
            _items.Added -= AddItem;
            _items.Removed -= RemoveItem;
        }
        
        private void ConfigureSize()
        {
            if (_items.Capacity == _slots.Count)
                return;
            
            if (_items.Capacity > _slots.Count)
            {
                AddNewSlots();
            }
            else
            {
                HideExcessiveSlots();
            }
        }

        private void AddNewSlots()
        {
            var slotsToAdd = _items.Capacity - _slots.Count;
            for (var i = 0; i < slotsToAdd; i++)
            {
                var newSlot = Instantiate(_slotPrefab, _slotContainer);
                newSlot.SetEmpty();
                newSlot.Dragged += OnSlotDragged;
                newSlot.DragEnded += OnSlotDragEnded;
                newSlot.Dropped += OnSlotDropped;
                _slots.Add(newSlot);
            }
        }
        
        private void HideExcessiveSlots()
        {
            for (var i = _items.Capacity; i < _slots.Count; i++)
            {
                _slots[i].Disable();
            }
        }

        private void OnSlotDragged(ItemSlot slot)
        {
            if (slot.Item.HasValue)
            {
                _hoveringItemSlot.SetItem(slot.Item.Value);
                slot.HideItem();
            }
        }
        
        private void OnSlotDragEnded(ItemSlot slot)
        {
            slot.ShowItem();
            _hoveringItemSlot.Hide();
        }
        
        private void OnSlotDropped(ItemSlot slot)
        {
            if (_hoveringItemSlot.HasItem)
            {
                slot.SetItem(_hoveringItemSlot.Item);
                _hoveringItemSlot.Hide();
            }
        }

        private void InitSlots(IEnumerable<Item> items)
        {
            foreach (var slot in _slots)
            {
                slot.SetEmpty();
            }
            foreach (var item in items)
            {
                _slots[item.Index].SetItem(item);
            }
        }
        
        private void AddItem(Item item) => _slots[item.Index].SetItem(item);

        private void RemoveItem(Item item) => _slots[item.Index].SetEmpty();
    }
}