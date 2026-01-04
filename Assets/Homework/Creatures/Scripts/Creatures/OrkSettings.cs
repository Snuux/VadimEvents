using System;
using UnityEngine;

[Serializable]
public class OrkSettings
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float Strength { get; private set; }
    [field: SerializeField] public bool HasAxe { get; private set; }
}