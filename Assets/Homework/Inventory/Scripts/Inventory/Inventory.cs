using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private readonly int _maxSize;
    private readonly List<Slot<Item>> _slots;

    public Inventory(int maxSize)
    {
        _slots = new();
        _maxSize = maxSize;
    }

    public int MaxSize => _maxSize;
    public int CurrentSize => _slots.Sum(slot => slot.Count);
    public IReadOnlyList<Slot<Item>> Slots => _slots;

    public void Add(Item item, int count = 1)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        
        int toAdd = Math.Min(count, _maxSize - CurrentSize);
        if (toAdd <= 0)
            return;

        Slot<Item> firstTargetSlot = _slots.FirstOrDefault(slot => slot.Item.Equals(item));

        if (firstTargetSlot == null)
        {
            firstTargetSlot = new Slot<Item>(item, toAdd);
            _slots.Add(firstTargetSlot);
        }
        else
        {
            firstTargetSlot.Add(toAdd);
        }
    }

    public bool TryAddBy(string itemName, out Item item, int count = 1)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        int toAdd = Math.Min(count, _maxSize - CurrentSize);
        
        Slot<Item> firstTargetSlot = _slots.FirstOrDefault(slot => slot.Item.Equals(itemName));

        if (firstTargetSlot == null || toAdd <= 0)
        {
            item = null;
            return false;
        }

        firstTargetSlot.Add(toAdd);
        item = firstTargetSlot.Item;
        return true;
    }

    public bool TryGetBy(string name, out int removedCount, int count = 1)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Slot<Item> firstTargetSlot = _slots.FirstOrDefault(slot => slot.Item.Equals(name));

        if (firstTargetSlot == null)
        {
            removedCount = 0;
            return false;
        }

        removedCount = firstTargetSlot.Get(count);
        
        if (firstTargetSlot.Count == 0)
            _slots.Remove(firstTargetSlot);
        
        return true;
    }

    public override string ToString()
    {
        string str = "";
        foreach (var slot in Slots)
            str += slot.Item?.Name + " " +  slot.Count + ", ";
        
        return "-- " + str + "Всего " + CurrentSize + "/" + MaxSize;
    }
}