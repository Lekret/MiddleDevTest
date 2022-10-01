using System;
using System.Collections.Generic;

namespace Trade.Scripts.Logic.Items
{
    public interface IItemContainer
    {
        IReadOnlyCollection<Item> Items { get; }
        int Capacity { get; }
        event Action<Item> Added;
        event Action<Item> Removed;
        void Add(Item item);
        void SetAt(Item item, int index);
        Item RemoveAt(int index);
    }
}