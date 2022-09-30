using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Trader", fileName = "Trader")]
    public class TraderData : ScriptableObject
    {
        [SerializeField] private ItemData[] _initialItems;
        [SerializeField] private float _sellCostMultiplier;

        public ItemData[] InitialItems => _initialItems;
        public float SellCostMultiplier => _sellCostMultiplier;
    }
}