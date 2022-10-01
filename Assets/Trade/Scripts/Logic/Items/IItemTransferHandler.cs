using Trade.Scripts.Logic.Items.TransferStrategies;

namespace Trade.Scripts.Logic.Items
{
    public interface IItemTransferHandler
    {
        void SetSource(
            IItemContainer sourceItems,
            Item sourceItem,
            IItemTransferStrategy sourceStrategy);

        void TransferTo(
            IItemContainer targetItems,
            Item targetItem,
            int targetSlotIndex, IItemTransferStrategy targetStrategy);

        void Clear();
    }
}