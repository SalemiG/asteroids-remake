using System;
using UnityEngine;

public static class EventManager
{
    public static event Action OnAsteroidExploded;

    public static void PlayAsteroidExploded()
    {
        OnAsteroidExploded?.Invoke();
    }

}
