using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Trader", fileName = "Trader")]
    public class TraderData : ScriptableObject
    {
        [SerializeField] private float _itemCostMultiplier = 2;
        [SerializeField] private ItemData[] _initialItems;

        public float ItemCostMultiplier => _itemCostMultiplier;
        public ItemData[] InitialItems => _initialItems;
    }
}