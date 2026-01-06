using System;
using UnityEngine;

namespace Homework.Creatures.Scripts.Creatures
{
    [Serializable]
    public class OrkSettings : CreatureSettings
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Strength { get; private set; }
        [field: SerializeField] public bool HasAxe { get; private set; }
    }
}