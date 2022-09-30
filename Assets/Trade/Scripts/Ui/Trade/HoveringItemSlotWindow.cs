using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class HoveringItemSlotWindow : UiWindow, IHoveringItemSlot
    {
        [SerializeField] private Image _icon;

        private bool _isActive;
        public bool HasItem => Item.IsValid();
        public Item Item { get; private set; }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetItem(Item item)
        {
            Item = item;
            _isActive = true;
            gameObject.SetActive(true);
            _icon.sprite = item.Data.Sprite;
        }

        public void Hide()
        {
            _isActive = false;
            Item = default;
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (!_isActive)
                return;
            transform.position = Input.mousePosition;
        }
    }
}