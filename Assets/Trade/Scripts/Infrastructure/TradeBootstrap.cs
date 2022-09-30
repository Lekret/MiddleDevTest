using System.Collections.Generic;
using Trade.Scripts.Logic;
using Trade.Scripts.StaticData;
using Trade.Scripts.Ui;
using Trade.Scripts.Ui.Core;
using Trade.Scripts.Ui.Handlers;
using Trade.Scripts.Ui.Trade;
using UnityEngine;

namespace Trade.Scripts.Infrastructure
{
    public class TradeBootstrap : MonoBehaviour
    {
        public UiConfiguration UiConfiguration;
        public PlayerData PlayerData;
        public TraderData TraderData;

        private void Awake()
        {
            var player = new Player(new Wallet(PlayerData.InitialCoins), new ItemContainer(10));
            AddItems(player.Items, PlayerData.InitialItems);
            var trader = new Trader(new Wallet(TraderData.InitialCoins), new ItemContainer(10));
            AddItems(trader.Items, TraderData.InitialItems, TraderData.SellCostMultiplier);
            
            var uiFactory = new UiFactory(UiConfiguration);
            uiFactory.Init();
            var draggableItemSlot = uiFactory.Create<DraggableItemSlotWindow>();
            uiFactory.Create<CoinsWindow>().Init(player.Wallet);
            var itemTransferHandler = new ItemTransferHandler();
            uiFactory.Create<TradeWindow>().Init(player.Items, trader.Items, draggableItemSlot, itemTransferHandler);
            draggableItemSlot.PlaceAsFirst();
        }

        private static void AddItems(ItemContainer items, IEnumerable<ItemData> itemData, float costMultiplier = 1)
        {
            foreach (var data in itemData)
            {
                items.Add(new Item(data, costMultiplier));
            }
        }
    }
}
