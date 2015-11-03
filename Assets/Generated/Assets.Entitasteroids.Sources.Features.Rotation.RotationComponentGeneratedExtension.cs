using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent rotation { get { return (Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent)GetComponent(ComponentIds.Rotation); } }

        public bool hasRotation { get { return HasComponent(ComponentIds.Rotation); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent> _rotationComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent>();

        public static void ClearRotationComponentPool() {
            _rotationComponentPool.Clear();
        }

        public Entity AddRotation(float newRotation) {
            var component = _rotationComponentPool.Count > 0 ? _rotationComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent();
            component.rotation = newRotation;
            return AddComponent(ComponentIds.Rotation, component);
        }

        public Entity ReplaceRotation(float newRotation) {
            var previousComponent = hasRotation ? rotation : null;
            var component = _rotationComponentPool.Count > 0 ? _rotationComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent();
            component.rotation = newRotation;
            ReplaceComponent(ComponentIds.Rotation, component);
            if (previousComponent != null) {
                _rotationComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveRotation() {
            var component = rotation;
            RemoveComponent(ComponentIds.Rotation);
            _rotationComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRotation;

        public static IMatcher Rotation {
            get {
                if (_matcherRotation == null) {
                    _matcherRotation = Matcher.AllOf(ComponentIds.Rotation);
                }

                return _matcherRotation;
            }
        }
    }
}
