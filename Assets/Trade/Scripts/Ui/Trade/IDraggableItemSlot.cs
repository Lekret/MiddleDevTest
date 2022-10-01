using Trade.Scripts.Logic;
using UnityEngine;

namespace Trade.Scripts.Ui.Trade
{
    public interface IDraggableItemSlot
    {
        bool IsDragging { get; }
        void SetItem(Item item);
        void SetPosition(Vector3 position);
        void Hide();
    }
}