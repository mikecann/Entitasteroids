using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent spaceship { get { return (Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent)GetComponent(ComponentIds.Spaceship); } }

        public bool hasSpaceship { get { return HasComponent(ComponentIds.Spaceship); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent> _spaceshipComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent>();

        public static void ClearSpaceshipComponentPool() {
            _spaceshipComponentPool.Clear();
        }

        public Entity AddSpaceship(float newAccelerationRate, float newRotationRate) {
            var component = _spaceshipComponentPool.Count > 0 ? _spaceshipComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent();
            component.accelerationRate = newAccelerationRate;
            component.rotationRate = newRotationRate;
            return AddComponent(ComponentIds.Spaceship, component);
        }

        public Entity ReplaceSpaceship(float newAccelerationRate, float newRotationRate) {
            var previousComponent = hasSpaceship ? spaceship : null;
            var component = _spaceshipComponentPool.Count > 0 ? _spaceshipComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent();
            component.accelerationRate = newAccelerationRate;
            component.rotationRate = newRotationRate;
            ReplaceComponent(ComponentIds.Spaceship, component);
            if (previousComponent != null) {
                _spaceshipComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSpaceship() {
            var component = spaceship;
            RemoveComponent(ComponentIds.Spaceship);
            _spaceshipComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSpaceship;

        public static IMatcher Spaceship {
            get {
                if (_matcherSpaceship == null) {
                    _matcherSpaceship = Matcher.AllOf(ComponentIds.Spaceship);
                }

                return _matcherSpaceship;
            }
        }
    }
}
