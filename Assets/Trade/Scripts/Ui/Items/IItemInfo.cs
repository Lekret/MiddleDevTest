﻿using Trade.Scripts.Logic.Items;
using UnityEngine;

namespace Trade.Scripts.Ui.Items
{
    public interface IItemInfo
    {
        void Show(Item item, Vector3 position);
        void Disable();
    }
}