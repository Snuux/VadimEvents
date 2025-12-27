using System;
using TMPro;
using UnityEngine;

public class EnemyBall : MonoBehaviour, IEntity
{
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float LifeTime { get; set; }
    [field: SerializeField] public EntityType EntityType { get; set;  }
    
    private Timer _timerToDestroy;
    private TMP_Text _timerText;

    private void Awake()
    {
        _timerText = GetComponentInChildren<TMP_Text>();
    }

    private void OnMouseUpAsButton()
    {
        Health -= 1000;
    }
    
    public void Initialize(float health, EntityType type, float lifeTime)
    {
        Health = health;
        LifeTime = lifeTime;
        EntityType = type;
        
        _timerToDestroy = new Timer(this, lifeTime);
        _timerToDestroy.Start();
        
        _timerToDestroy.Changed += UpdateLifeTime;
        _timerToDestroy.Changed += UpdateInfoText;
    }

    private void UpdateLifeTime(float time)
    {
        LifeTime = time;
    }

    private void OnDestroy()
    {
        _timerToDestroy.Changed -= UpdateInfoText;
        _timerToDestroy.Changed -= UpdateLifeTime;
    }

    private void UpdateInfoText(float time)
    {
        if (_timerText != null)
        {
            float resultTime = Mathf.Clamp(time + .02f, 0, float.MaxValue);
            _timerText.text = resultTime.ToString("F1");
        }
    }
    
    public void Destroy()
    { 
        Destroy(gameObject);
    }
}