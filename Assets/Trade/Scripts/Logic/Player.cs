using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Player
    {
        public Wallet Wallet { get; }
        public ItemContainer Items { get; }

        public Player(Wallet wallet, ItemContainer items)
        {
            Wallet = wallet;
            Items = items;
        }
    }
}