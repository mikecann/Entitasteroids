using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

public static class EntityExtensions
{
    public static void FindEmptyPosition(this Entity entity, float radius, Bounds bounds, IEnumerable<Entity> entities)
    {
        for (var i = 0; i < 100; i++)
        {
            var pos = bounds.RandomPosition();
            if (entity.CollidesWithOthers(pos, entities))
                continue;
            entity.ReplacePosition(pos.x, pos.y);
            return;
        }
        throw new Exception("Could not find empty position!");
    }

    public static bool CollidesWithOthers(this Entity entity, Vector2 pos, IEnumerable<Entity> entities)
    {
        foreach (var e in entities)
        {
            if (!e.hasCollisionRadius || !e.hasPosition)
                continue;

            if (e == entity)
                continue;

            var delta = new Vector2(pos.x - e.position.x, pos.y - e.position.y);
            var minDist = entity.collisionRadius.radius + e.collisionRadius.radius;
            var minDistSqr = minDist*minDist;

            if (delta.sqrMagnitude < minDistSqr)
                return true;
        }

        return false;
    }
}
