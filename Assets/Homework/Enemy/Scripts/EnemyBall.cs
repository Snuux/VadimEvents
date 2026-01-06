using TMPro;
using UnityEngine;

namespace Homework.Enemy.Scripts
{
    public class EnemyBall : MonoBehaviour, IEntity
    {
        [field: SerializeField] public float Health { get; set; }
        [field: SerializeField] public float LifeTime { get; set; }
        [field: SerializeField] public EntityType EntityType { get; set;  }
    
        private Timer.Scripts.Timer _timerToDestroy;
        private TMP_Text _timerText;

        private void Awake()
        {
            _timerText = GetComponentInChildren<TMP_Text>();
        }

        private void OnMouseUpAsButton()
        {
            Health -= 1000;
        }

        private void OnDestroy()
        {
            _timerToDestroy.ReactiveCurrentTime.Changed -= UpdateInfoText;
            _timerToDestroy.ReactiveCurrentTime.Changed -= UpdateLifeTime;
        }
    
        public void Initialize(float health, EntityType type, float lifeTime)
        {
            Health = health;
            LifeTime = lifeTime;
            EntityType = type;
        
            _timerToDestroy = new Timer.Scripts.Timer(this, lifeTime);
            _timerToDestroy.Start();
        
            _timerToDestroy.ReactiveCurrentTime.Changed += UpdateLifeTime;
            _timerToDestroy.ReactiveCurrentTime.Changed += UpdateInfoText;
        }

        private void UpdateLifeTime(float oldTime,float time)
        {
            LifeTime = time;
        }

        private void UpdateInfoText(float oldTime, float time)
        {
            if (_timerText != null)
            {
                float resultTime = Mathf.Clamp(time + .02f, 0, float.MaxValue);
                _timerText.text = resultTime.ToString("F1");
            }
        }
    }
}