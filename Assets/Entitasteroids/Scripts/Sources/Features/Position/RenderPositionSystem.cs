using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Position
{
    public class RenderPositionSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var z = entity.view.gameObject.transform.position.z;
                entity.view.gameObject.transform.position.Set(entity.position.x, entity.position.y, z);
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Position, Matcher.View).OnEntityAdded(); }
        }
    }
}
