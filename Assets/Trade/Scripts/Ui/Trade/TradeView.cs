using Trade.Scripts.Logic.Items;
using Trade.Scripts.Ui.Core;
using Trade.Scripts.Ui.Items;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public class TradeView : UiView
    {
        [SerializeField] private ItemGrid _playerGrid;
        [SerializeField] private ItemGrid _traderGrid;
        
        public void Init(ItemContainer player,
            ItemContainer trader,
            IDraggableItemSlot draggableItemSlot,
            IItemTransferHandler itemTransferHandler, 
            IItemInfo itemInfo)
        {
            _playerGrid.Init(player, draggableItemSlot, itemTransferHandler, itemInfo);
            _traderGrid.Init(trader, draggableItemSlot, itemTransferHandler, itemInfo);
        }
    }
}