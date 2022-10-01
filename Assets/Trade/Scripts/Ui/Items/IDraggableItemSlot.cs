﻿using Trade.Scripts.Logic.Items;
using UnityEngine;

namespace Trade.Scripts.Ui.Items
{
    public interface IDraggableItemSlot
    {
        bool IsDragging { get; }
        void SetItem(Item item);
        void SetPosition(Vector3 position);
        void Hide();
    }
}