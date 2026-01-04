using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public float Damage { get; protected set; }
    public float Health { get; protected set; }

    public override string ToString() => $"Наносит {Damage} урона. У него {Health} здоровья.";
}