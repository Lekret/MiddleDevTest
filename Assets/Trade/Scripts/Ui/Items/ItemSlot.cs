using System;
using Trade.Scripts.Logic.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Trade.Scripts.Ui.Items
{
    public class ItemSlot : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler,
        IPointerEnterHandler, IPointerExitHandler, IDropHandler
    {
        [SerializeField] private Image _icon;

        public int Index { get; set; }
        public Item Item { get; private set; }
        public event Action<ItemSlot, PointerEventData> DragBegan;
        public event Action<ItemSlot, PointerEventData> Dragged;
        public event Action<ItemSlot> DragEnded;
        public event Action<ItemSlot> Dropped;
        public event Action<ItemSlot> PointerEntered;
        public event Action<ItemSlot> PointerExited;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) => DragBegan?.Invoke(this, eventData);

        void IDragHandler.OnDrag(PointerEventData eventData) => Dragged?.Invoke(this, eventData);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => DragEnded?.Invoke(this);

        void IDropHandler.OnDrop(PointerEventData eventData) => Dropped?.Invoke(this);

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => PointerEntered?.Invoke(this);

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => PointerExited?.Invoke(this);

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