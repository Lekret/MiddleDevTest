using System;
using System.Collections.Generic;

namespace Trade.Scripts.Logic.Items
{
    public class ItemContainer : IItemContainer
    {
        private readonly Dictionary<int, Item> _items = new Dictionary<int, Item>();
        private readonly int _capacity;

        public ItemContainer(int capacity)
        {
            _capacity = capacity;
        }

        public IReadOnlyCollection<Item> Items => _items.Values;
        public int Capacity => _capacity;
        public event Action<Item> Added;
        public event Action<Item> Removed;

        public void Add(Item item)
        {
            if (_items.Count > _capacity)
                return;
            item.Index = _items.Count;
            _items.Add(item.Index, item);
            Added?.Invoke(item);
        }

        public void SetAt(Item item, int index)
        {
            item.Index = index;
            _items[index] = item;
            Added?.Invoke(item);
        }

        public Item RemoveAt(int index)
        {
            var item = _items[index];
            _items.Remove(index);
            Removed?.Invoke(item);
            return item;
        }
    }
}