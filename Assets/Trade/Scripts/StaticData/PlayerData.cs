using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player", fileName = "Player")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private ItemData[] _initialItems;

        public ItemData[] InitialItems => _initialItems;
    }
}