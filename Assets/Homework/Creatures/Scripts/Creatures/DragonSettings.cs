using System;
using UnityEngine;

namespace Homework.Creatures.Scripts.Creatures
{
    [Serializable]
    public class DragonSettings : CreatureSettings
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float FireCapacity { get; private set; }
        [field: SerializeField] public int HeadsCount { get; private set; }
    }
}