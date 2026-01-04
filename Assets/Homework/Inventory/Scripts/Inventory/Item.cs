using System;

public class Item : IEquatable<Item>
{
    public Item(string name) => Name = name;

    public string Name { get; }

    public bool Equals(Item other) => Name.Equals(other?.Name);
    public bool Equals(string otherName) => Name.Equals(otherName);
}