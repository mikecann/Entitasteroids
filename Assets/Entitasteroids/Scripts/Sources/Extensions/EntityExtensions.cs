using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

public static class EntityExtensions
{
    public static void FindEmptyPosition(this Entity entity, float radius, Bounds bounds)
    {
        var pos = bounds.RandomPosition();
        entity.ReplacePosition(pos.x, pos.y);

    }
}
