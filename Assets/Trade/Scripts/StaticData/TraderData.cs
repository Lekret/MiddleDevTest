using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Trader", fileName = "Trader")]
    public class TraderData : ScriptableObject
    {
        [SerializeField] private int _initialCoins;
        [SerializeField] private float _sellCostMultiplier;
        [SerializeField] private ItemData[] _initialItems;

        public int InitialCoins => _initialCoins;
        public float SellCostMultiplier => _sellCostMultiplier;
        public ItemData[] InitialItems => _initialItems;
    }
}