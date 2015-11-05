using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Position
{
    public class RenderPositionSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var x = entity.position.x;
                var y = entity.position.y;
                var z = entity.view.gameObject.transform.position.z;
                var pos = entity.view.gameObject.transform.position;

                if (x != pos.x || y != pos.y)
                    entity.view.gameObject.transform.position = new Vector3(x, y, z);
                    
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Position, Matcher.View).OnEntityAdded(); }
        }
    }
}
