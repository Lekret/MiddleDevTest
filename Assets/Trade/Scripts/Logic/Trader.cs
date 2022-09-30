namespace Trade.Scripts.Logic
{
    public class Trader
    {
        public Wallet Wallet { get; }
        public ItemContainer Items { get; }

        public Trader(Wallet wallet, ItemContainer items)
        {
            wallet = wallet;
            Items = items;
        }
    }
}
