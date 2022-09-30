using Trade.Scripts.Logic;
using Trade.Scripts.Ui.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class HoveringItemSlotWindow : UiWindow, IHoveringItemSlot
    {
        [SerializeField] private Image _icon;

        public Item Item { get; private set; }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetItem(Item item)
        {
            Item = item;
            gameObject.SetActive(true);
            _icon.sprite = item.Data.Sprite;
        }

        public void Hide()
        {
            Item = default;
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (Item.IsValid())
            {
                transform.position = Input.mousePosition;
            }
        }
    }
}