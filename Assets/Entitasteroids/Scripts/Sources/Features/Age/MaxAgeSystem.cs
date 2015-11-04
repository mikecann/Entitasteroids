using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Age
{
    public class MaxAgeSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                if (entity.age.age >= entity.maxAge.maxAge)
                    entity.isDestroying = true;
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Age, Matcher.MaxAge).OnEntityAdded(); }
        }
    }
}
