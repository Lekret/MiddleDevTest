using Trade.Scripts.Logic.Items;
using Trade.Scripts.Logic.Items.TransferStrategies;
using Trade.Scripts.Ui.Core;
using Trade.Scripts.Ui.DraggableItemSlot;
using Trade.Scripts.Ui.ItemInfo;
using Trade.Scripts.Ui.Items;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public class TradeView : UiView
    {
        [SerializeField] private ItemGrid _playerGrid;
        [SerializeField] private ItemGrid _traderGrid;

        public void Init(
            IItemContainer player,
            IItemContainer trader,
            IItemTransferHandler itemTransferHandler,
            IItemTransferStrategy playerStrategy,
            IItemTransferStrategy traderStrategy,
            IDraggableItemSlot draggableItemSlot,
            IItemInfo itemInfo)
        {
            _playerGrid.Init(player, draggableItemSlot, itemTransferHandler, playerStrategy, itemInfo);
            _traderGrid.Init(trader, draggableItemSlot, itemTransferHandler, traderStrategy, itemInfo);
        }
    }
}