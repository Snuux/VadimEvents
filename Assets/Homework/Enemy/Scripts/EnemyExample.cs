using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework.Enemy.Scripts
{
    public class EnemyExample : MonoBehaviour
    {
        private const float SpawnRange = 3f;
    
        [SerializeField] private EnemyBall _enemyVisualRedPrefab;
        [SerializeField] private EnemyBall _enemyVisualBluePrefab;
        [SerializeField] private EnemyBall _enemyVisualYellowPrefab;
    
        private EnemyDestroyerHandler _enemyDestroyerHandler;
    
        private List<IEntity> _enemies = new ();
    
        private void Awake()
        {
            _enemyDestroyerHandler = new EnemyDestroyerHandler();
        }

        private void Update()
        {
            _enemyDestroyerHandler.UpdateLogic();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                IEntity enemy = AddEnemy(_enemyVisualRedPrefab, EntityType.Red);
            
                _enemyDestroyerHandler.Add(enemy, (entity) => entity.Health <= 0);
                _enemyDestroyerHandler.Add(enemy, (entity) => entity.EntityType == EntityType.Yellow);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                IEntity enemy = AddEnemy(_enemyVisualBluePrefab, EntityType.Blue);
            
                _enemyDestroyerHandler.Add(enemy, (entity) => entity.LifeTime <= 0.02f);
                _enemyDestroyerHandler.Add(enemy, (entity) => entity.EntityType == EntityType.Yellow);
            }

            if (Input.GetKeyDown(KeyCode.F))
                if (_enemies.Count > 0)
                    _enemies[Random.Range(0, _enemies.Count)].EntityType = EntityType.Yellow;

            CheckEnemiesArray();
        }

        private void CheckEnemiesArray()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
                if ((_enemies[i] as UnityEngine.Object) == null)
                    _enemies.RemoveAt(i);
        }

        private IEntity AddEnemy(EnemyBall visualPrefab, EntityType entityType)
        {
            EnemyBall enemy = Instantiate(visualPrefab, RandomSpawnPosition(), Quaternion.identity);
            enemy.Initialize(100, entityType, 3);
            _enemies.Add(enemy);

            return enemy;
        }

        private Vector3 RandomSpawnPosition() => new(Random.Range(-SpawnRange, SpawnRange), Random.Range(-SpawnRange, SpawnRange), 0);
    }
}