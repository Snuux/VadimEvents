using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private List<Creature> _allCreatures = new();
    
    public IReadOnlyList<Creature> AllCreatures => _allCreatures;
    
    public void Spawn(Creature creature, object settings)
    {
        Creature spawnedCreature = Object.Instantiate(creature);

        if (spawnedCreature == null)
            return;
        
        _allCreatures.Add(spawnedCreature);
        
        if (settings is DragonSettings dragonSetting)
        {
            Dragon dragon = spawnedCreature as Dragon;
            dragon?.Initialize(
                dragonSetting.Damage, dragonSetting.Health, dragonSetting.FireCapacity, dragonSetting.HeadsCount);
        }
        else if (settings is ElfSettings elfSettings)
        {
            Elf elf = spawnedCreature as Elf;
            elf?.Initialize(elfSettings.Damage, elfSettings.Health, elfSettings.Mana, elfSettings.Wisdom);
        }
        else if (settings is OrkSettings orkSettings)
        {
            Ork ork = spawnedCreature as Ork;
            ork?.Initialize(orkSettings.Damage, orkSettings.Health, orkSettings.HasAxe, orkSettings.Strength);
        }
        else
        {
            throw new System.NotImplementedException("No setting for " + settings.GetType().Name);
        }
    }
}