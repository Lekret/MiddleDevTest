﻿using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public class TradeWindow : UiWindow
    {
        [SerializeField] private ItemGrid _playerGrid;
        [SerializeField] private ItemGrid _traderGrid;
        
        public void Init(ItemContainer player, ItemContainer trader, IHoveringItemSlot hoveringItemSlot)
        {
            _playerGrid.Init(player, hoveringItemSlot);
            _traderGrid.Init(trader, hoveringItemSlot);
        }
    }
}