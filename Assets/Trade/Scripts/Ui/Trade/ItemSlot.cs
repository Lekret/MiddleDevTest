using System;
using Trade.Scripts.Logic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Trade
{
    public class ItemSlot : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] private Image _icon;

        public Item Item { get; private set; }
        public event Action<ItemSlot> Dragged;
        public event Action<ItemSlot> Dropped;
        public event Action<ItemSlot> DragEnded;

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (Item.IsValid())
                Dragged?.Invoke(this);
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            if (Item.IsValid())
                DragEnded?.Invoke(this);
        }

        void IDropHandler.OnDrop(PointerEventData eventData) => Dropped?.Invoke(this);

        public void SetItem(Item item)
        {
            Item = item;
            gameObject.SetActive(true);
            _icon.enabled = true;
            _icon.sprite = item.Data.Sprite;
        }

        public void SetEmpty()
        {
            Item = default;
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
            Item = default;
            gameObject.SetActive(false);
        }
    }
}