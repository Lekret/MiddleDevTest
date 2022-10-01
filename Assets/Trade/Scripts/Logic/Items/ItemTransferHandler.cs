using Trade.Scripts.Logic.Items.TransferStrategies;

namespace Trade.Scripts.Logic.Items
{
    public class ItemTransferHandler : IItemTransferHandler
    {
        private ItemContainer _sourceItems;
        private Item _sourceItem;
        private IItemTransferStrategy _sourceStrategy;

        public void SetSource(ItemContainer sourceItems, Item sourceItem, IItemTransferStrategy sourceStrategy)
        {
            _sourceItems = sourceItems;
            _sourceItem = sourceItem;
            _sourceStrategy = sourceStrategy;
        }

        public void TransferTo(
            ItemContainer targetItems,
            Item targetItem, 
            int targetSlotIndex, 
            IItemTransferStrategy targetStrategy)
        {
            if (_sourceItems == null || _sourceStrategy == null || !_sourceItem.IsValid())
                return;

            var isSameContainer = _sourceItems == targetItems;
            if (isSameContainer)
            {
                TransferInsideSource(targetItem, targetSlotIndex);
            }
            else
            {
                TransferByStrategies(targetItems, targetItem, targetSlotIndex, targetStrategy);
            }
            Clear();
        }
        
        private void TransferInsideSource(Item targetItem, int targetSlotIndex)
        {
            _sourceItems.SetAt(_sourceItem, targetSlotIndex);
            var needSwap = targetItem.IsValid();
            if (needSwap)
            {
                _sourceItems.SetAt(targetItem, _sourceItem.Index);
            }
            else
            {
                _sourceItems.RemoveAt(_sourceItem.Index);
            }
        }

        private void TransferByStrategies(
            ItemContainer targetItems, 
            Item targetItem,
            int targetSlotIndex, 
            IItemTransferStrategy targetStrategy)
        {
            if (!targetStrategy.CanTransfer(_sourceItem))
                return;

            var needSwap = targetItem.IsValid();
            if (needSwap && !_sourceStrategy.CanTransfer(targetItem))
                return;
            
            targetStrategy.BeforeTransfer(ref _sourceItem);
            targetItems.SetAt(_sourceItem, targetSlotIndex);
            
            if (needSwap)
            {
                _sourceStrategy.BeforeTransfer(ref targetItem);
                _sourceItems.SetAt(targetItem, _sourceItem.Index);
            }
            else
            {
                _sourceItems.RemoveAt(_sourceItem.Index);
            }
        }

        public void Clear()
        {
            _sourceItem = default;
            _sourceItems = null;
            _sourceStrategy = null;
        }
    }
}