using UnityEngine;

public class Ork : Creature
{
    public bool HasAxe { get; private set; }
    public float Strength { get; private set; }

    public void Initialize(float damage, float health, bool hasAxe, float strength)
    {
        Damage = damage;
        Health = health;
        HasAxe = hasAxe;
        Strength = strength;
    }
    
    public override string ToString()
    {
        string desc = "Орк ";
        
        if (HasAxe)
            desc += "с огромным топором, ";
        
        return desc + $"с силой {Strength}. " + base.ToString();
    }
}