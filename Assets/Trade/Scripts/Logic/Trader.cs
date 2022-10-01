using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Trader
    {
        public ItemContainer Items { get; }

        public Trader(ItemContainer items)
        {
            Items = items;
        }
    }
}
