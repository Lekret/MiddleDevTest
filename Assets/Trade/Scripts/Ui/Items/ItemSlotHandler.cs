using Trade.Scripts.Logic.Items;
using Trade.Scripts.Logic.Items.TransferStrategies;
using Trade.Scripts.Ui.DraggableItemSlot;
using Trade.Scripts.Ui.ItemInfo;
using UnityEngine.EventSystems;

namespace Trade.Scripts.Ui.Items
{
    public class ItemSlotHandler
    {
        private readonly IItemContainer _items;
        private readonly IDraggableItemSlot _draggableItemSlot;
        private readonly IItemTransferHandler _itemTransferHandler;
        private readonly IItemTransferStrategy _itemTransferStrategy;
        private readonly IItemInfo _itemInfo;

        public ItemSlotHandler(
            IItemContainer items,
            IDraggableItemSlot draggableItemSlot,
            IItemTransferHandler itemTransferHandler,
            IItemTransferStrategy itemTransferStrategy,
            IItemInfo itemInfo)
        {
            _items = items;
            _draggableItemSlot = draggableItemSlot;
            _itemTransferHandler = itemTransferHandler;
            _itemInfo = itemInfo;
            _itemTransferStrategy = itemTransferStrategy;
        }

        public void OnSlotDragBegan(ItemSlot slot, PointerEventData eventData)
        {
            if (!slot.Item.IsValid())
                return;
            _draggableItemSlot.SetItem(slot.Item);
            _draggableItemSlot.SetPosition(eventData.position);
            _itemTransferHandler.SetSource(_items, slot.Item, _itemTransferStrategy);
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
            _itemTransferHandler.TransferTo(_items, slot.Item, slot.Index, _itemTransferStrategy);
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