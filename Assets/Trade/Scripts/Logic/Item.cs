using Trade.Scripts.StaticData;

namespace Trade.Scripts.Logic
{
    public struct Item
    {
        public readonly ItemData Data;
        public int Index;
        public int Cost;
        
        public Item(ItemData itemData)
        {
            Data = itemData;
            Index = 0;
            Cost = 0;
        }

        public bool IsValid()
        {
            return Data != null;
        }
    }
}