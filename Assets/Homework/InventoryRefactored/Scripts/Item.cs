using System;
using JetBrains.Annotations;

namespace Homework.InventoryRefactored.Scripts
{
    public class Item : IReadOnlyItem
    {
        public string Name {get; private set;}

        public Item(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Item item && item.Name == Name)
                return true;
            
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(Name);
    }
}