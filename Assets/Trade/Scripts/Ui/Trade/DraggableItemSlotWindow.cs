using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class DraggableItemSlotWindow : UiWindow, IDraggableItemSlot
    {
        [SerializeField] private Image _icon;

        private Item _item;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetItem(Item item)
        {
            _item = item;
            gameObject.SetActive(true);
            _icon.sprite = item.Data.Sprite;
        }

        public void Hide()
        {
            _item = default;
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (_item.IsValid())
            {
                transform.position = Input.mousePosition;
            }
        }
    }
}