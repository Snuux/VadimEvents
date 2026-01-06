using System;
using UnityEngine;

namespace Homework.Creatures.Scripts.Creatures
{
    [Serializable]
    public class ElfSettings : CreatureSettings
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Mana { get; private set; }
        [field: SerializeField] public float Wisdom { get; private set; }
    }
}