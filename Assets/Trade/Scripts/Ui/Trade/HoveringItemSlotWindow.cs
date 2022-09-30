using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class HoveringItemSlotWindow : UiWindow, IHoveringItemSlot
    {
        [SerializeField] private Image _icon;

        private bool _active;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetItem(Item item)
        {
            _active = true;
            gameObject.SetActive(true);
            _icon.sprite = item.Data.Sprite;
        }

        public void Disable()
        {
            _active = false;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!_active)
                return;
            transform.position = Input.mousePosition;
        }
    }
}