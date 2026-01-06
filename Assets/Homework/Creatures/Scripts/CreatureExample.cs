using System;
using System.Collections.Generic;
using Homework.Creatures.Scripts.Creatures;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework.Creatures.Scripts
{
    public class CreatureExample : MonoBehaviour
    {
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private List<OrkSettings> _orkSettings;
        
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private List<ElfSettings> _elfSettings;
        
        [SerializeField] private Dragon _dragonPrefab;
        [SerializeField] private List<DragonSettings> _dragonSettings;
        
        [SerializeField] private int _countToSpawn;
        
        private Spawner _spawner;
    
        private void Awake()
        {
            _spawner = new Spawner(_orkPrefab, _elfPrefab, _dragonPrefab);
    
            for (int i = 0; i < _countToSpawn; i++)
            {
                _spawner.Spawn(_orkSettings[Random.Range(0, _orkSettings.Count)]);
                _spawner.Spawn(_elfSettings[Random.Range(0, _elfSettings.Count)]);
                _spawner.Spawn(_dragonSettings[Random.Range(0, _dragonSettings.Count)]);
            }
            
            foreach (var creature in _spawner.AllCreatures)
                Debug.Log(creature.ToString());
        }
    }
}

