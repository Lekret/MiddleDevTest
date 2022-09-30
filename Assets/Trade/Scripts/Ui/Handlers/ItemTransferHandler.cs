using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Trade;

namespace Trade.Scripts.Ui.Handlers
{
    public class ItemTransferHandler : IItemTransferHandler
    {
        private ItemSlot _sourceSlot;
        private ItemContainer _sourceItems;
        
        public void SetSource(ItemContainer sourceItems, ItemSlot sourceSlot)
        {
            _sourceSlot = sourceSlot;
            _sourceItems = sourceItems;
            sourceSlot.HideItem();
        }

        public void TransferTo(ItemContainer targetItems, ItemSlot targetSlot)
        {
            if (_sourceSlot == null)
                return;
            
            var targetItem = targetSlot.Item;
            targetItems.SetAt(_sourceSlot.Item, targetSlot.Index);
            
            if (targetItem.IsValid())
            {
                _sourceItems.SetAt(targetItem, _sourceSlot.Item.Index);
            }
            else
            {
                _sourceItems.RemoveAt(_sourceSlot.Item.Index);
            }
            _sourceSlot = null;
        }

        public void Clear()
        {
            _sourceSlot = null;
        }
    }
}