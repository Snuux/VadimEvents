using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homework.InventoryRefactored.Scripts
{
    public class Inventory
    {
        private Dictionary<IReadOnlyItem, int> _items = new();

        public int CurrentSize => _items.Sum(item => item.Value);
        public int MaxSize { get; private set; }

        public Inventory(List<IReadOnlyItem> items, int maxSize)
        {
            if (maxSize < 0)
                throw new ArgumentOutOfRangeException(nameof(maxSize));
            
            items.ForEach(item => _items.Add(item, 1));
            MaxSize = maxSize;
        }
        
        public void Add(IReadOnlyItem item) => Add(item, out _);

        public void Add(IReadOnlyItem item, out int notAddedCount, int count = 1)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            int emptySpace = MaxSize - CurrentSize;
            int toAdd = Math.Min(count, emptySpace);

            if (_items.TryAdd(item, toAdd) == false)
                _items[item] += toAdd;
            
            notAddedCount = count - toAdd;
        }
        
        public bool TryGet(IReadOnlyItem item, out int gotCount, int count = 1)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_items.TryGetValue(item, out var itemCount) == false)
            {
                gotCount = 0;
                return false;
            }

            int toGet = Math.Min(count, itemCount);
            _items[item] -= toGet;
            
            gotCount = toGet;
            
            if (_items[item] == 0)
                _items.Remove(item);

            return true;
        }

        //legacy after refactor
        public List<IReadOnlyItem> GetItemsBy(string name, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            List<IReadOnlyItem> returnedItems = new();
            IReadOnlyItem item = _items
                .FirstOrDefault(pair => pair.Key.Name == name)
                .Key;
            
            if (item == null)
                return returnedItems;

            if (TryGet(item, out int gotCount, count) == false)
                return returnedItems;

            for (int i = 0; i < gotCount; i++)
                returnedItems.Add(item);
            
            return returnedItems;
        }
        
        public override string ToString()
        {
            string str = "";
            foreach (var pair in _items)
                str += pair.Key?.Name + " " +  pair.Value + ", ";
        
            return "-- " + str + "Всего " + CurrentSize + "/" + MaxSize;
        }
    }
}