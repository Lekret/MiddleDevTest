using Trade.Scripts.Logic;

namespace Trade.Scripts.Ui.Handlers
{
    public class ItemTransferHandler : IItemTransferHandler
    {
        private Item _sourceItem;
        private ItemContainer _sourceItems;

        public void SetSource(ItemContainer sourceItems, Item sourceItem)
        {
            _sourceItems = sourceItems;
            _sourceItem = sourceItem;
        }

        public void TransferTo(ItemContainer targetItems, Item targetItem, int targetSlotIndex)
        {
            if (_sourceItems == null || !_sourceItem.IsValid())
                return;
            
            targetItems.SetAt(_sourceItem, targetSlotIndex);
            
            if (targetItem.IsValid())
            {
                _sourceItems.SetAt(targetItem, _sourceItem.Index);
            }
            else
            {
                _sourceItems.RemoveAt(_sourceItem.Index);
            }
            Clear();
        }

        public void Clear()
        {
            _sourceItem = default;
            _sourceItems = null;
        }
    }
}