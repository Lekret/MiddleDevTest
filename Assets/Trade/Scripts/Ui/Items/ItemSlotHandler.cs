using Trade.Scripts.Logic.Items;
using UnityEngine.EventSystems;

namespace Trade.Scripts.Ui.Items
{
    public class ItemSlotHandler
    {
        private readonly ItemContainer _items;
        private readonly IDraggableItemSlot _draggableItemSlot;
        private readonly IItemTransferHandler _itemTransferHandler;
        private readonly IItemInfo _itemInfo;

        public ItemSlotHandler(
            ItemContainer items,
            IDraggableItemSlot draggableItemSlot, 
            IItemTransferHandler itemTransferHandler,
            IItemInfo itemInfo)
        {
            _items = items;
            _draggableItemSlot = draggableItemSlot;
            _itemTransferHandler = itemTransferHandler;
            _itemInfo = itemInfo;
        }

        public void OnSlotDragBegan(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetItem(slot.Item);
            _draggableItemSlot.SetPosition(eventData.position);
            _itemTransferHandler.SetSource(_items, slot.Item);
            _itemInfo.Disable();
            slot.HideItem();
        }
        
        public void OnSlotDragged(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetPosition(eventData.position);
        }

        public void OnSlotDragEnded(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.Hide();
            _itemTransferHandler.Clear();
            slot.ShowItem();
        }
        
        public void OnSlotDropped(ItemSlot slot)
        {
            _itemTransferHandler.TransferTo(_items, slot.Item, slot.Index);
            _draggableItemSlot.Hide();
            if (slot.Item.IsValid())
            {
                _itemInfo.Show(slot.Item, slot.transform.position);
            }
        }

        public void OnSlotPointerEntered(ItemSlot slot)
        {
            if (!slot.Item.IsValid())
                return;
            if (_draggableItemSlot.IsDragging)
                return;
            _itemInfo.Show(slot.Item, slot.transform.position);
        }
        
        public void OnSlotPointerExited(ItemSlot slot)
        {
            _itemInfo.Disable();
        }
    }
}