using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Age
{
    public class AgingSystem : ISetPool, IReactiveSystem
    {
        private Group _ages;

        public void SetPool(Pool pool)
        {
            _ages = pool.GetGroup(Matcher.Age);
        }

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                Age(entity.tick.delta);
        }

        public void Age(float amount)
        {
            foreach (var entity in _ages.GetEntities())
                entity.ReplaceAge(entity.age.age + amount);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Tick.OnEntityAdded(); }
        }
    }
}
