using System.Collections.Generic;
using Trade.Scripts.Logic;
using Trade.Scripts.StaticData;
using Trade.Scripts.Ui;
using Trade.Scripts.Ui.Core;
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
            var player = new Player();
            AddItems(player.Items, PlayerData.InitialItems);
            
            var trader = new Trader();
            AddItems(trader.Items, TraderData.InitialItems);
            var uiFactory = new UiFactory(UiConfiguration);
            uiFactory.Init();
            uiFactory.Create<CoinsWindow>().Init(player.Wallet);
            uiFactory.Create<TradeWindow>().Init(player.Items, trader.Items);
        }

        private static void AddItems(ItemContainer items, IEnumerable<ItemData> itemData)
        {
            foreach (var data in itemData)
            {
                items.Add(new Item(data));
            }
        }
    }
}
