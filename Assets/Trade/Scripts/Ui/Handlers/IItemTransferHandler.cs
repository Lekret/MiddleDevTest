using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Trade;

namespace Trade.Scripts.Ui.Handlers
{
    public interface IItemTransferHandler
    {
        void SetSource(ItemContainer sourceItems, ItemSlot sourceSlot);
        void TransferTo(ItemContainer targetItems, ItemSlot targetSlot);
        void Clear();
    }
}