namespace Homework.Enemy.Scripts
{
    public interface IEntity
    {
        float Health { get; set; }
        float LifeTime { get; set; }
        EntityType EntityType { get; set; }
    }
}