using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Trader", fileName = "Trader")]
    public class TraderData : ScriptableObject
    {
        [SerializeField] private float _sellCostDecreaseMultiplier;
        [SerializeField] private ItemData[] _initialItems;

        public float SellCostDecreaseMultiplier => _sellCostDecreaseMultiplier;
        public ItemData[] InitialItems => _initialItems;
    }
}