namespace Trade.Scripts.Logic.Items
{
    public interface IItemTransferHandler
    {
        void SetSource(ItemContainer sourceItems, Item sourceItem);
        void TransferTo(ItemContainer targetItems, Item targetItem, int targetSlotIndex);
        void Clear();
    }
}