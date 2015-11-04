using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Input
{
    public class InputDestructionSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                entity.isDestroying = true;
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Input.OnEntityAdded(); }
        }
    }
}
