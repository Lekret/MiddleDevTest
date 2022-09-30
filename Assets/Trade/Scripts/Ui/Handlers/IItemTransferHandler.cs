using Trade.Scripts.Logic;

namespace Trade.Scripts.Ui.Handlers
{
    public interface IItemTransferHandler
    {
        void SetSource(ItemContainer sourceItems, Item sourceItem);
        void TransferTo(ItemContainer targetItems, Item targetItem, int targetSlotIndex);
        void Clear();
    }
}