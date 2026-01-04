using System;
using UnityEngine;

[Serializable]
public class ElfSettings
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float Mana { get; private set; }
    [field: SerializeField] public float Wisdom { get; private set; }
}