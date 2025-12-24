using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    [SerializeField] private EnemyDestroyerHandler _enemyDestroyerHandler;
    
    [SerializeField] private EnemyBall _enemyVisualRedPrefab;
    [SerializeField] private EnemyBall _enemyVisualYellowPrefab;
    [SerializeField] private EnemyBall _enemyVisualBluePrefab;
    
    private void Awake()
    {
        /*
        //в общем это был нормальный пример без монобехавироров. 
        //Как только их добавляю и пытаюсь связать, получается каша
         
        Enemy enemy1 = new Enemy(100, EntityType.Blue, 5);
        Enemy enemy2 = new Enemy(50, EntityType.Yellow, 3);
        Enemy enemy3 = new Enemy(120, EntityType.Red, 8);
        
        _enemyDestroyerHandler = new EnemyDestroyerHandler();
        _enemyDestroyerHandler.Add(enemy1, (enemy) => enemy.IsDead());
        _enemyDestroyerHandler.Add(enemy2, (enemy) => enemy.Size >= 2);
        _enemyDestroyerHandler.Add(enemy3, (enemy) => enemy.EntityType == EntityType.Red);
        
        _enemyDestroyerHandler.Add(enemy1, (enemy) => enemy.EntityType == EntityType.Blue);

        List<Enemy> enemiesToDestroy = _enemyDestroyerHandler.GetEnemiesToDestroy();

        Debug.Log("Destroyed enemies: ");
        foreach (var enemy in enemiesToDestroy)
        {
            _enemyDestroyerHandler.Destroy(enemy);
            Debug.Log(enemy.GetInfo());
        }*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnemyBall enemy = Instantiate(_enemyVisualRedPrefab, 
                new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)),
                Quaternion.identity
                );
            
            enemy.Initialize(100, EntityType.Red, 5);
            
            _enemyDestroyerHandler.Add(enemy, (entity) => entity.IsDead());
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnemyBall enemy = Instantiate(_enemyVisualBluePrefab, 
                new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)),
                Quaternion.identity
            );
            
            enemy.Initialize(100, EntityType.Blue, 3);
            
            _enemyDestroyerHandler.Add(enemy, (entity) => entity.Size <= 0.02f);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnemyBall enemy = Instantiate(_enemyVisualYellowPrefab, 
                new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)),
                Quaternion.identity
            );
            
            enemy.Initialize(100, EntityType.Yellow, 7);
            
            _enemyDestroyerHandler.Add(enemy, (entity) => entity.EntityType == EntityType.Yellow);
        }
    }
}