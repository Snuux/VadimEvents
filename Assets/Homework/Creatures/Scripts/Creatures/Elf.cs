public class Elf : Creature
{
    private const float WisdomThreshold = 20f;
    
    public float Mana { get; private set; }
    public float Wisdom { get; private set; }
    
    public void Initialize(float damage, float health, float mana, float wisdom)
    {
        Damage = damage;
        Health = health;
        Wisdom = wisdom;
        Mana = mana;
    }
    
    public override string ToString()
    {
        string desc = "";

        if (Wisdom >= WisdomThreshold)
            desc += $"Мудрый маг ";
        else
            desc += $"Начинающий маг ";
        
        return desc + $"с мудростью {Wisdom} и маной {Mana}. " + base.ToString();
    }
}