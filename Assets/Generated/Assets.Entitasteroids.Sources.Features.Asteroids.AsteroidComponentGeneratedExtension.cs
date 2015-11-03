using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent asteroid { get { return (Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent)GetComponent(ComponentIds.Asteroid); } }

        public bool hasAsteroid { get { return HasComponent(ComponentIds.Asteroid); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent> _asteroidComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent>();

        public static void ClearAsteroidComponentPool() {
            _asteroidComponentPool.Clear();
        }

        public Entity AddAsteroid(Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidSize newSize) {
            var component = _asteroidComponentPool.Count > 0 ? _asteroidComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent();
            component.size = newSize;
            return AddComponent(ComponentIds.Asteroid, component);
        }

        public Entity ReplaceAsteroid(Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidSize newSize) {
            var previousComponent = hasAsteroid ? asteroid : null;
            var component = _asteroidComponentPool.Count > 0 ? _asteroidComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent();
            component.size = newSize;
            ReplaceComponent(ComponentIds.Asteroid, component);
            if (previousComponent != null) {
                _asteroidComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAsteroid() {
            var component = asteroid;
            RemoveComponent(ComponentIds.Asteroid);
            _asteroidComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAsteroid;

        public static IMatcher Asteroid {
            get {
                if (_matcherAsteroid == null) {
                    _matcherAsteroid = Matcher.AllOf(ComponentIds.Asteroid);
                }

                return _matcherAsteroid;
            }
        }
    }
}
