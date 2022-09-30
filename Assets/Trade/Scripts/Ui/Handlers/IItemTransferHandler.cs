using Trade.Scripts.Ui.Trade;

namespace Trade.Scripts.Ui.Handlers
{
    public interface IItemTransferHandler
    {
        void SetSource(ItemSlot source);
        void TransferTo(ItemSlot target);
        void Clear();
    }
}