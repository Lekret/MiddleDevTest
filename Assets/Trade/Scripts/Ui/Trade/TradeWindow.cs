using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using Trade.Scripts.Ui.Handlers;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public class TradeWindow : UiWindow
    {
        [SerializeField] private ItemGrid _playerGrid;
        [SerializeField] private ItemGrid _traderGrid;
        
        public void Init(
            ItemContainer player, 
            ItemContainer trader,
            IDraggableItemSlot draggableItemSlot,
            IItemTransferHandler itemTransferHandler)
        {
            _playerGrid.Init(player, draggableItemSlot, itemTransferHandler);
            _traderGrid.Init(trader, draggableItemSlot, itemTransferHandler);
        }
    }
}