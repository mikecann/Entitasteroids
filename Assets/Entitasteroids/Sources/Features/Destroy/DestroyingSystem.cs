using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Destroy
{
    public class DestroyingSystem : IReactiveSystem, ISetPool
    {
        private Pool _pool;

        public void Execute(List<Entity> entities)
        {
            foreach (var e in entities)
                _pool.DestroyEntity(e);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Destroyed.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
        }
    }
}
