using System;
using Trade.Scripts.Logic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Trade.Scripts.Ui
{
    public class ItemSlot : MonoBehaviour, IDragHandler
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private Image _icon;

        public event Action<PointerEventData> Dragged;
        
        void IDragHandler.OnDrag(PointerEventData eventData) => Dragged?.Invoke(eventData);

        public void SetItem(Item item)
        {
            _root.SetActive(true);
            _icon.enabled = true;
            _icon.sprite = item.Data.Sprite;
        }

        public void Clear()
        {
            _icon.enabled = false;
        }

        public void Hide()
        {
            _root.SetActive(false);
        }
    }
}