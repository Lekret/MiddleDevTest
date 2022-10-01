using Trade.Scripts.Logic.Items;

namespace Trade.Scripts.Logic
{
    public class Trader
    {
        public IItemContainer Items { get; }
        public float ItemCostMultiplier { get; }

        public Trader(IItemContainer items, float itemCostMultiplier)
        {
            Items = items;
            ItemCostMultiplier = itemCostMultiplier;
        }
    }
}