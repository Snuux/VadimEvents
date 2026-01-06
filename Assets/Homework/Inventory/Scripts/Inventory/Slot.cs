using System;

namespace Homework.Inventory.Scripts.Inventory
{
    public class Slot<T> : IEquatable<T>
    {
        private int _count;

        public Slot(T item, int count = 1)
        {
            Count = count;
            Item = item;
        }

        public T Item { get; private set; }

        public int Count
        {
            get => _count;
            private set
            {
                _count = value;
            
                if (_count < 0)
                {
                    Count = 0;
                    Item = default;
                }
                else if (Count == 0)
                {
                    Item = default;
                }
            }
        }

        public bool IsEmpty => Count == 0;

        public void Clear() => Count = 0;

        public void Add(int count = 1)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
        
            Count += count;
        }

        public int Get(int count = 1)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
        
            int removed = Math.Min(Count, count);
            Count -= removed;
        
            return removed;
        }

        public bool Equals(T other) => other != null && other.Equals(Item);
    }
}