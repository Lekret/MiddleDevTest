using Trade.Scripts.Ui.Trade;

namespace Trade.Scripts.Ui.Handlers
{
    public class ItemTransferHandler : IItemTransferHandler
    {
        private ItemSlot _source;
        
        public void SetSource(ItemSlot source)
        {
            _source = source;
            source.HideItem();
        }

        public void TransferTo(ItemSlot target)
        {
            if (_source == null)
                return;
            
            var targetItem = target.Item;
            target.SetItem(_source.Item);
            
            if (targetItem.IsValid())
            {
                _source.SetItem(targetItem);
            }
            else
            {
                _source.SetEmpty();
            }
            _source = null;
        }

        public void Clear()
        {
            _source = null;
        }
    }
}