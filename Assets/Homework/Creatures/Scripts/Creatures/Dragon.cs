public class Dragon : Creature
{
    public float FireCapacity { get; private set; }
    public int HeadsCount { get; private set; }
    
    public void Initialize(float damage, float health, float fireCapacity, int headsCount)
    {
        Damage = damage;
        Health = health;
        FireCapacity = fireCapacity;
        HeadsCount = headsCount;
    }
    
    public override string ToString() => 
        $"Дракон с {HeadsCount} головой/головами. Его пламенный запас - {FireCapacity}. " + base.ToString();
}