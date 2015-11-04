using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Player
{
    public class PlayerSpawningSystem : IReactiveSystem, ISetPool
    {
        private Pool _pool;

        public void Execute(List<Entity> entities)
        {
            for (var index = 0; index < entities.Count; index++)
                _pool.CreatePlayer(true);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Game, Matcher.Playing).OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
        }
    }
}
