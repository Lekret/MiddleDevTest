using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;

namespace Trade.Scripts.Ui
{
    public class TradeWindow : UiWindow
    {
        [SerializeField] private ItemGrid _playerGrid;
        [SerializeField] private ItemGrid _traderGrid;

        public void Init(ItemContainer player, ItemContainer trader)
        {
            _playerGrid.Init(player);
            _traderGrid.Init(trader);
        }
    }
}