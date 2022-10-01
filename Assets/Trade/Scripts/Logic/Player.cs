using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Player
    {
        public Wallet Wallet { get; }
        public IItemContainer Items { get; }

        public Player(Wallet wallet, IItemContainer items)
        {
            Wallet = wallet;
            Items = items;
        }
    }
}