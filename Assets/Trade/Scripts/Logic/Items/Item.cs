using Trade.Scripts.StaticData;
using UnityEngine;

namespace Trade.Scripts.Logic.Items
{
    public struct Item
    {
        public readonly ItemData Data;
        public int Index;
        public int Cost;

        public Item(ItemData itemData, float costMultiplier = 1)
        {
            Data = itemData;
            Cost = Mathf.CeilToInt(itemData.DefaultCost * costMultiplier);
            Index = 0;
        }

        public bool IsValid()
        {
            return Data != null;
        }
    }
}