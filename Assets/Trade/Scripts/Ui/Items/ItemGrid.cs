using System.Collections.Generic;
using Trade.Scripts.Logic.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Trade.Scripts.Ui.Items
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
                newSlot.DragBegan += OnSlotDragBegan;
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

        private void OnSlotDragBegan(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetItem(slot.Item);
            _draggableItemSlot.SetPosition(eventData.position);
            _itemTransferHandler.SetSource(_items, slot.Item);
            _itemInfo.Disable();
            slot.HideItem();
        }
        
        private void OnSlotDragged(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetPosition(eventData.position);
        }

        private void OnSlotDragEnded(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.Hide();
            _itemTransferHandler.Clear();
            slot.ShowItem();
        }
        
        private void OnSlotDropped(ItemSlot slot)
        {
            _itemTransferHandler.TransferTo(_items, slot.Item, slot.Index);
            _draggableItemSlot.Hide();
            if (slot.Item.IsValid())
            {
                _itemInfo.Show(slot.Item, slot.transform.position);
            }
        }

        private void OnSlotPointerEntered(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            if (_draggableItemSlot.IsDragging)
                return;
            _itemInfo.Show(slot.Item, slot.transform.position);
        }
        
        private void OnSlotPointerExited(ItemSlot slot)
        {
            _itemInfo.Disable();
        }

        private void AddItem(Item item) => _slots[item.Index].SetItem(item);

        private void RemoveItem(Item item) => _slots[item.Index].SetEmpty();
    }
}