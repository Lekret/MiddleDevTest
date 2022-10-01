using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Trader
    {
        public Wallet Wallet { get; }
        public ItemContainer Items { get; }

        public Trader(Wallet wallet, ItemContainer items)
        {
            Wallet = wallet;
            Items = items;
        }
    }
}
