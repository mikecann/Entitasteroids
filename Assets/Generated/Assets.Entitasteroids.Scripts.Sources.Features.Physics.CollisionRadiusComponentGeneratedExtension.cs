using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent collisionRadius { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent)GetComponent(ComponentIds.CollisionRadius); } }

        public bool hasCollisionRadius { get { return HasComponent(ComponentIds.CollisionRadius); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent> _collisionRadiusComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent>();

        public static void ClearCollisionRadiusComponentPool() {
            _collisionRadiusComponentPool.Clear();
        }

        public Entity AddCollisionRadius(float newRadius) {
            var component = _collisionRadiusComponentPool.Count > 0 ? _collisionRadiusComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent();
            component.radius = newRadius;
            return AddComponent(ComponentIds.CollisionRadius, component);
        }

        public Entity ReplaceCollisionRadius(float newRadius) {
            var previousComponent = hasCollisionRadius ? collisionRadius : null;
            var component = _collisionRadiusComponentPool.Count > 0 ? _collisionRadiusComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent();
            component.radius = newRadius;
            ReplaceComponent(ComponentIds.CollisionRadius, component);
            if (previousComponent != null) {
                _collisionRadiusComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveCollisionRadius() {
            var component = collisionRadius;
            RemoveComponent(ComponentIds.CollisionRadius);
            _collisionRadiusComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherCollisionRadius;

        public static IMatcher CollisionRadius {
            get {
                if (_matcherCollisionRadius == null) {
                    _matcherCollisionRadius = Matcher.AllOf(ComponentIds.CollisionRadius);
                }

                return _matcherCollisionRadius;
            }
        }
    }
}
