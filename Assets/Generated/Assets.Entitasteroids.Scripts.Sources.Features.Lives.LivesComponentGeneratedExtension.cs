using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent lives { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent)GetComponent(ComponentIds.Lives); } }

        public bool hasLives { get { return HasComponent(ComponentIds.Lives); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent> _livesComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent>();

        public static void ClearLivesComponentPool() {
            _livesComponentPool.Clear();
        }

        public Entity AddLives(int newLives) {
            var component = _livesComponentPool.Count > 0 ? _livesComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent();
            component.lives = newLives;
            return AddComponent(ComponentIds.Lives, component);
        }

        public Entity ReplaceLives(int newLives) {
            var previousComponent = hasLives ? lives : null;
            var component = _livesComponentPool.Count > 0 ? _livesComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent();
            component.lives = newLives;
            ReplaceComponent(ComponentIds.Lives, component);
            if (previousComponent != null) {
                _livesComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveLives() {
            var component = lives;
            RemoveComponent(ComponentIds.Lives);
            _livesComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherLives;

        public static IMatcher Lives {
            get {
                if (_matcherLives == null) {
                    _matcherLives = Matcher.AllOf(ComponentIds.Lives);
                }

                return _matcherLives;
            }
        }
    }
}
