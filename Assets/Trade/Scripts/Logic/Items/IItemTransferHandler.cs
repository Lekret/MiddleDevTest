using Trade.Scripts.Logic.Items.TransferStrategies;

namespace Trade.Scripts.Logic.Items
{
    public interface IItemTransferHandler
    {
        void SetSource(
            ItemContainer sourceItems,
            Item sourceItem,
            IItemTransferStrategy sourceStrategy);
        void TransferTo(
            ItemContainer targetItems,
            Item targetItem,
            int targetSlotIndex, IItemTransferStrategy targetStrategy);
        void Clear();
    }
}