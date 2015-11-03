using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent rigidbody { get { return (Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent)GetComponent(ComponentIds.Rigidbody); } }

        public bool hasRigidbody { get { return HasComponent(ComponentIds.Rigidbody); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent> _rigidbodyComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent>();

        public static void ClearRigidbodyComponentPool() {
            _rigidbodyComponentPool.Clear();
        }

        public Entity AddRigidbody(UnityEngine.Rigidbody2D newRigidbody) {
            var component = _rigidbodyComponentPool.Count > 0 ? _rigidbodyComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent();
            component.rigidbody = newRigidbody;
            return AddComponent(ComponentIds.Rigidbody, component);
        }

        public Entity ReplaceRigidbody(UnityEngine.Rigidbody2D newRigidbody) {
            var previousComponent = hasRigidbody ? rigidbody : null;
            var component = _rigidbodyComponentPool.Count > 0 ? _rigidbodyComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent();
            component.rigidbody = newRigidbody;
            ReplaceComponent(ComponentIds.Rigidbody, component);
            if (previousComponent != null) {
                _rigidbodyComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveRigidbody() {
            var component = rigidbody;
            RemoveComponent(ComponentIds.Rigidbody);
            _rigidbodyComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRigidbody;

        public static IMatcher Rigidbody {
            get {
                if (_matcherRigidbody == null) {
                    _matcherRigidbody = Matcher.AllOf(ComponentIds.Rigidbody);
                }

                return _matcherRigidbody;
            }
        }
    }
}
