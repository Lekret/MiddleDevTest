using System.Collections.Generic;
using Trade.Scripts.Logic.Items;
using UnityEngine;

namespace Trade.Scripts.Ui.Items
{
    public class ItemGrid : MonoBehaviour
    {
        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotContainer;

        private ItemContainer _items;
        private ItemSlotHandler _itemSlotHandler;
        private readonly List<ItemSlot> _slots = new List<ItemSlot>();

        public void Init(ItemContainer items,
            IDraggableItemSlot draggableItemSlot,
            IItemTransferHandler itemTransferHandler, 
            IItemInfo itemInfo)
        {
            _items = items;
            _itemSlotHandler = new ItemSlotHandler(
                items, 
                draggableItemSlot, 
                itemTransferHandler, 
                itemInfo);
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
                newSlot.Index = _slots.Count;
                newSlot.SetEmpty();
                newSlot.DragBegan += _itemSlotHandler.OnSlotDragBegan;
                newSlot.Dragged += _itemSlotHandler.OnSlotDragged;
                newSlot.DragEnded += _itemSlotHandler.OnSlotDragEnded;
                newSlot.Dropped += _itemSlotHandler.OnSlotDropped;
                newSlot.PointerEntered += _itemSlotHandler.OnSlotPointerEntered;
                newSlot.PointerExited += _itemSlotHandler.OnSlotPointerExited;
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