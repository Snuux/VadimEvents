using UnityEngine;

public class EnemyBall : MonoBehaviour, Entity
{
    private Timer _timerToDestroy;
    
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float Size { get; set; }
    [field: SerializeField] public EntityType EntityType { get; set;  }
    
    public void Initialize(float health, EntityType type, float size)
    {
        Health = health;
        Size = size;
        EntityType = type;
        
        float timerTimeFromSize = Size;
        _timerToDestroy = new Timer(this, timerTimeFromSize);
        _timerToDestroy.Start();

        UpdateSize();
        
        _timerToDestroy.OnChanged += UpdateSize;
    }
    
    public bool IsDead() => Health <= 0;

    public string GetInfo() => $"Health: {Health},  Size: {Size},  Type: {EntityType.ToString()}";

    private void OnMouseUpAsButton()
    {
        Health -= 1000;
    }

    private void OnDestroy()
    {
        _timerToDestroy.OnChanged -= UpdateSize;
    }

    private void UpdateSize()
    {
        Size = _timerToDestroy.CurrentTime;
        
        transform.localScale = Vector3.one * Size;
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}