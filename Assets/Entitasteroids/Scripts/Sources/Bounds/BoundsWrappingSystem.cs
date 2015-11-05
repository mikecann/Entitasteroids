using System.Collections.Generic;
using Assets.Entitasteroids.Sources.Features.Position;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Bounds
{
    public class BoundsWrappingSystem : IReactiveSystem, ISetPool, IEnsureComponents
    {
        private Group _gameBounds;

        public void Execute(List<Entity> entities)
        {
            var bounds = _gameBounds.GetSingleEntity();
            if (bounds == null)
                return;

            foreach (var entity in entities)
                Wrap(entity, bounds.bounds.bounds);
        }

        private void Wrap(Entity entity, UnityEngine.Bounds bounds)
        {
            var position = entity.position;

            if (position.x < bounds.min.x)
                entity.ReplacePosition(position.x + bounds.size.x, position.y);

            if (position.x > bounds.max.x)
                entity.ReplacePosition(position.x - bounds.size.x, position.y);

            if (position.y < bounds.min.y)
                entity.ReplacePosition(position.x, position.y + bounds.size.y);

            if (position.y > bounds.max.y)
                entity.ReplacePosition(position.x, position.y - bounds.size.y);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Position, Matcher.WrappedAroundGameBounds).OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _gameBounds = pool.GetGroup(Matcher.AllOf(Matcher.Game, Matcher.Bounds));
        }

        public IMatcher ensureComponents {
            get { return Matcher.Position; }
        }
    }
}
