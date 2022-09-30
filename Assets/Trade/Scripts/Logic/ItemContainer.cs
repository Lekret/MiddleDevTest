using System;
using System.Collections.Generic;

namespace Trade.Scripts.Logic
{
    public class ItemContainer
    {
        private readonly int _capacity;
        private readonly Dictionary<int, Item> _items = new Dictionary<int, Item>();
        public IReadOnlyCollection<Item> Items => _items.Values;
        public int Capacity => _capacity;

        public event Action<Item> Added;
        public event Action<Item> Removed;

        public ItemContainer(int capacity)
        {
            _capacity = capacity;
        }

        public void Add(Item item)
        {
            if (_items.Count > _capacity)
                return;
            item.Index = _items.Count;
            _items.Add(item.Index, item);
            Added?.Invoke(item);
        }

        public void AddAt(Item item, int index)
        {
            item.Index = index;
            _items.Add(index, item);
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