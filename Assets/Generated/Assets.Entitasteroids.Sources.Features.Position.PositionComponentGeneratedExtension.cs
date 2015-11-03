using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Position.PositionComponent position { get { return (Assets.Entitasteroids.Sources.Features.Position.PositionComponent)GetComponent(ComponentIds.Position); } }

        public bool hasPosition { get { return HasComponent(ComponentIds.Position); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Position.PositionComponent> _positionComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Position.PositionComponent>();

        public static void ClearPositionComponentPool() {
            _positionComponentPool.Clear();
        }

        public Entity AddPosition(float newX, float newY) {
            var component = _positionComponentPool.Count > 0 ? _positionComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Position.PositionComponent();
            component.x = newX;
            component.y = newY;
            return AddComponent(ComponentIds.Position, component);
        }

        public Entity ReplacePosition(float newX, float newY) {
            var previousComponent = hasPosition ? position : null;
            var component = _positionComponentPool.Count > 0 ? _positionComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Position.PositionComponent();
            component.x = newX;
            component.y = newY;
            ReplaceComponent(ComponentIds.Position, component);
            if (previousComponent != null) {
                _positionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemovePosition() {
            var component = position;
            RemoveComponent(ComponentIds.Position);
            _positionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPosition;

        public static IMatcher Position {
            get {
                if (_matcherPosition == null) {
                    _matcherPosition = Matcher.AllOf(ComponentIds.Position);
                }

                return _matcherPosition;
            }
        }
    }
}
