using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Item", fileName = "Item")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private int _cost;
        [SerializeField] private Sprite _sprite;

        public string Id => _id;
        public string Name => _name;
        public int DefaultCost => _cost;
        public Sprite Sprite => _sprite;
    }
}