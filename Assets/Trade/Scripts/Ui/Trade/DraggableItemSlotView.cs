using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class DraggableItemSlotView : UiView, IDraggableItemSlot
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Image _icon;

        private Item _item;

        private void Awake()
        {
            _container.SetActive(false);
        }

        public void SetItem(Item item)
        {
            _item = item;
            _container.SetActive(true);
            _icon.sprite = item.Data.Sprite;
        }

        public void Hide()
        {
            _item = default;
            _container.SetActive(false);
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