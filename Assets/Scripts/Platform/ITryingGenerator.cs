using UnityEngine;
using System;

public interface ITryingGenerator
{
    public event Action<Vector2> OnTriedSpawn;
}