using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class BoundsExtensions
{
    public static Vector2 RandomPosition(this UnityEngine.Bounds bounds)
    {
        return new Vector2(UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
           UnityEngine.Random.Range(bounds.min.y, bounds.max.y));
    }
}