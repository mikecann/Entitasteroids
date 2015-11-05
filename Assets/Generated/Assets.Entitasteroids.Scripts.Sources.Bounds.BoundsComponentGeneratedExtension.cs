using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent bounds { get { return (Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent)GetComponent(ComponentIds.Bounds); } }

        public bool hasBounds { get { return HasComponent(ComponentIds.Bounds); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent> _boundsComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent>();

        public static void ClearBoundsComponentPool() {
            _boundsComponentPool.Clear();
        }

        public Entity AddBounds(UnityEngine.Bounds newBounds) {
            var component = _boundsComponentPool.Count > 0 ? _boundsComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent();
            component.bounds = newBounds;
            return AddComponent(ComponentIds.Bounds, component);
        }

        public Entity ReplaceBounds(UnityEngine.Bounds newBounds) {
            var previousComponent = hasBounds ? bounds : null;
            var component = _boundsComponentPool.Count > 0 ? _boundsComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent();
            component.bounds = newBounds;
            ReplaceComponent(ComponentIds.Bounds, component);
            if (previousComponent != null) {
                _boundsComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveBounds() {
            var component = bounds;
            RemoveComponent(ComponentIds.Bounds);
            _boundsComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherBounds;

        public static IMatcher Bounds {
            get {
                if (_matcherBounds == null) {
                    _matcherBounds = Matcher.AllOf(ComponentIds.Bounds);
                }

                return _matcherBounds;
            }
        }
    }
}
