using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player", fileName = "Player")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private int _initialCoins;
        [SerializeField] private ItemData[] _initialItems;

        public int InitialCoins => _initialCoins;
        public ItemData[] InitialItems => _initialItems;
    }
}