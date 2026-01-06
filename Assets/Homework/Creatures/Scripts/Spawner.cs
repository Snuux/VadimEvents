using System.Collections.Generic;
using UnityEngine;
using Homework.Creatures.Scripts.Creatures;

namespace Homework.Creatures.Scripts
{
    public class Spawner
    {
        private readonly List<Creature> _allCreatures = new();

        private readonly Ork _orkPrefab;
        private readonly Elf _elfPrefab;
        private readonly Dragon _dragonPrefab;

        public Spawner(Ork ork, Elf elf, Dragon dragon)
        {
            _orkPrefab = ork;
            _elfPrefab = elf;
            _dragonPrefab = dragon;
        }
        
        public IReadOnlyList<Creature> AllCreatures => _allCreatures;

        public void Spawn(CreatureSettings settings)
        {
            switch (settings)
            {
                case DragonSettings dragonSetting:
                {
                    Dragon dragonInstance = Object.Instantiate(_dragonPrefab);

                    if (dragonInstance == null)
                        throw new System.NullReferenceException("DragonInstance is null");

                    dragonInstance.Initialize(
                        dragonSetting.Damage, dragonSetting.Health, dragonSetting.FireCapacity, dragonSetting.HeadsCount);

                    _allCreatures.Add(dragonInstance);
                    break;
                }
                case ElfSettings elfSettings:
                {
                    Elf elfInstance = Object.Instantiate(_elfPrefab);

                    if (elfInstance == null)
                        throw new System.NullReferenceException("ElfInstance is null");

                    elfInstance.Initialize(
                        elfSettings.Damage, elfSettings.Health, elfSettings.Mana, elfSettings.Wisdom);

                    _allCreatures.Add(elfInstance);
                    break;
                }
                case OrkSettings orkSettings:
                {
                    Ork orkInstance = Object.Instantiate(_orkPrefab);

                    if (orkInstance == null)
                        throw new System.NullReferenceException("OrkInstance is null");

                    orkInstance.Initialize(
                        orkSettings.Damage, orkSettings.Health, orkSettings.HasAxe, orkSettings.Strength);

                    _allCreatures.Add(orkInstance);
                    break;
                }
                default:
                {
                    throw new System.NotImplementedException("No setting for " + settings.GetType().Name);
                }
            }
        }
    }
}