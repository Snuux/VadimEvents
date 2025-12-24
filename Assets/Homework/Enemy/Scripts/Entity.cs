public interface Entity
{
    float Health { get; set; }
    float Size { get; set; }
    EntityType EntityType { get; set; }
    
    bool IsDead();
    
    void Destroy();
    
    string GetInfo();
}