using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyerHandler : MonoBehaviour
{
    private List< KeyValuePair<Entity, Func<Entity, bool>> > _entities = new();

    public void Update()
    {
        foreach (var entity in GetEnemiesToDestroy())
        {
            DestroyEntity(entity);
        }
    }
    
    public List<Entity> GetEnemiesToDestroy()
    {
        List<Entity> selectedEnemies = new List<Entity>();

        foreach (var Entity in _entities)
        {
            if (Entity.Value(Entity.Key))
                selectedEnemies.Add(Entity.Key);
        }

        return selectedEnemies;
    }

    public void Add(Entity Entity, Func<Entity, bool> conditionToDestroy)
    {
        var element = new KeyValuePair<Entity, Func<Entity, bool>>(Entity, conditionToDestroy);
        _entities.Add(element);
    }

    public void DestroyEntity(Entity entityToDestroy)
    {
        _entities.RemoveAll(x => x.Key == entityToDestroy);
        
        entityToDestroy.Destroy();
    }
}
