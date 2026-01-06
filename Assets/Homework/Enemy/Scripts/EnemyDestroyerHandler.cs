using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework.Enemy.Scripts
{
    public class EnemyDestroyerHandler
    {
        private Dictionary< IEntity, List<Predicate<IEntity>> > _entities = new();

        public void UpdateLogic()
        {
            foreach (var entity in GetEnemiesToDestroy())
                TryDestroyEntity(entity);
        }
    
        public List<IEntity> GetEnemiesToDestroy()
        {
            List<IEntity> selectedEnemies = new();

            foreach (var entity in _entities)
            foreach (var predicate in entity.Value)
                if (predicate(entity.Key))
                    selectedEnemies.Add(entity.Key);

            return selectedEnemies;
        }

        public void Add(IEntity entity, Predicate<IEntity> conditionToDestroy)
        {
            if (_entities.TryGetValue(entity, out var predicates))
                predicates.Add(conditionToDestroy);
            else
                _entities.Add(entity, new List<Predicate<IEntity>> { conditionToDestroy });
        }

        public bool TryDestroyEntity(IEntity entityToDestroy)
        {
            if (entityToDestroy is Component unityComponent)
            {
                UnityEngine.Object.Destroy(unityComponent.gameObject);
                _entities.Remove(entityToDestroy);
                return true;
            }
            else
            {
                Debug.LogError($"{entityToDestroy} doesn't implement {nameof(Component)}");
                return false;
            }
        }

        public void RemovePredicateFromEntity(IEntity entity, Predicate<IEntity> predicateToDestroy)
        {
            if (_entities.TryGetValue(entity, out var predicates))
                predicates.Remove(predicateToDestroy);
        }
    }
}
