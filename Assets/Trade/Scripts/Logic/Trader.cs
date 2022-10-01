using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Trader
    {
        public ItemContainer Items { get; }
        public float ItemCostMultiplier { get; }

        public Trader(ItemContainer items, float itemCostMultiplier)
        {
            Items = items;
            ItemCostMultiplier = itemCostMultiplier;
        }
    }
}