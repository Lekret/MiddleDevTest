using TMPro;
using Trade.Scripts.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _cost;
        
        public void SetItem(Item item)
        {
            _icon.enabled = true;
            _icon.sprite = item.Data.Sprite;
            _cost.text = $"{item.Cost}";
        }

        public void Clear()
        {
            _icon.enabled = false;
            _cost.text = "";
        }
    }
}