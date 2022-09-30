using Trade.Scripts.Ui.Core;
using UnityEngine;

namespace Trade.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Ui", fileName = "UiConfiguration")]
    public class UiConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private UiWindow[] _windows;

        public GameObject Root => _root;
        public UiWindow[] Windows => _windows;
    }
}