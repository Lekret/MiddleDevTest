using System.Collections.Generic;
using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Handlers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Trade.Scripts.Ui.Trade
{
    public class ItemGrid : MonoBehaviour
    {
        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotContainer;

        private ItemContainer _items;
        private IDraggableItemSlot _draggableItemSlot;
        private IItemTransferHandler _itemTransferHandler;
        private IItemInfo _itemInfo;
        private readonly List<ItemSlot> _slots = new List<ItemSlot>();

        public void Init(ItemContainer items,
            IDraggableItemSlot draggableItemSlot,
            IItemTransferHandler itemTransferHandler, 
            IItemInfo itemInfo)
        {
            _items = items;
            _draggableItemSlot = draggableItemSlot;
            _itemTransferHandler = itemTransferHandler;
            _itemInfo = itemInfo;
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
                newSlot.Dragged += OnSlotDragged;
                newSlot.DragEnded += OnSlotDragEnded;
                newSlot.Dropped += OnSlotDropped;
                newSlot.PointerEntered += OnSlotPointerEntered;
                newSlot.PointerExited += OnSlotPointerExited;
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

        private void OnSlotDragged(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetItem(slot.Item);
            _itemTransferHandler.SetSource(_items, slot.Item);
            slot.HideItem();
        }
        
        private void OnSlotDragEnded(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.Hide();
            _itemTransferHandler.Clear();
            _itemInfo.Disable();
            slot.ShowItem();
        }
        
        private void OnSlotDropped(ItemSlot slot, PointerEventData eventData)
        {
            _draggableItemSlot.Hide();
            _itemTransferHandler.TransferTo(_items, slot.Item, slot.Index);
            _itemInfo.Show(slot.Item, eventData.position);
        }

        private void OnSlotPointerEntered(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _itemInfo.Show(slot.Item, eventData.position);
        }
        
        private void OnSlotPointerExited(ItemSlot slot)
        {
            _itemInfo.Disable();
        }

        private void AddItem(Item item) => _slots[item.Index].SetItem(item);

        private void RemoveItem(Item item) => _slots[item.Index].SetEmpty();
    }
}