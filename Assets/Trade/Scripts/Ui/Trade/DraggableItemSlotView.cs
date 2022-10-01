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

        public bool IsDragging => _item.IsValid();

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

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Hide()
        {
            _item = default;
            _container.SetActive(false);
        }
    }
}