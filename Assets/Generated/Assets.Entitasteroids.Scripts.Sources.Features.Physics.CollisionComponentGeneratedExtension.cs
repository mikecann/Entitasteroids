using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent collision { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent)GetComponent(ComponentIds.Collision); } }

        public bool hasCollision { get { return HasComponent(ComponentIds.Collision); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent> _collisionComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent>();

        public static void ClearCollisionComponentPool() {
            _collisionComponentPool.Clear();
        }

        public Entity AddCollision(UnityEngine.Collision2D newCollision) {
            var component = _collisionComponentPool.Count > 0 ? _collisionComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent();
            component.collision = newCollision;
            return AddComponent(ComponentIds.Collision, component);
        }

        public Entity ReplaceCollision(UnityEngine.Collision2D newCollision) {
            var previousComponent = hasCollision ? collision : null;
            var component = _collisionComponentPool.Count > 0 ? _collisionComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent();
            component.collision = newCollision;
            ReplaceComponent(ComponentIds.Collision, component);
            if (previousComponent != null) {
                _collisionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveCollision() {
            var component = collision;
            RemoveComponent(ComponentIds.Collision);
            _collisionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherCollision;

        public static IMatcher Collision {
            get {
                if (_matcherCollision == null) {
                    _matcherCollision = Matcher.AllOf(ComponentIds.Collision);
                }

                return _matcherCollision;
            }
        }
    }
}
