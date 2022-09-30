using System;
using Trade.Scripts.Logic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _icon;

        public Item? Item { get; private set; }
        public event Action<ItemSlot> PointerDown;
        public event Action<ItemSlot> PointerUp;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) =>
            PointerDown?.Invoke(this);

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData) =>
            PointerUp?.Invoke(this);

        public void SetItem(Item item)
        {
            Item = item;
            gameObject.SetActive(true);
            _icon.enabled = true;
            _icon.sprite = item.Data.Sprite;
        }

        public void SetEmpty()
        {
            Item = null;
            gameObject.SetActive(true);
            _icon.enabled = false;
        }

        public void HideItem()
        {
            _icon.enabled = false;
        }

        public void ShowItem()
        {
            _icon.enabled = true;
        }
        
        public void Disable()
        {
            Item = null;
            gameObject.SetActive(false);
        }
    }
}