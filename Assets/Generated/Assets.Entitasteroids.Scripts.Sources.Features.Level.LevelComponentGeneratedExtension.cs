using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent level { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent)GetComponent(ComponentIds.Level); } }

        public bool hasLevel { get { return HasComponent(ComponentIds.Level); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent> _levelComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent>();

        public static void ClearLevelComponentPool() {
            _levelComponentPool.Clear();
        }

        public Entity AddLevel(int newLevel) {
            var component = _levelComponentPool.Count > 0 ? _levelComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent();
            component.level = newLevel;
            return AddComponent(ComponentIds.Level, component);
        }

        public Entity ReplaceLevel(int newLevel) {
            var previousComponent = hasLevel ? level : null;
            var component = _levelComponentPool.Count > 0 ? _levelComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent();
            component.level = newLevel;
            ReplaceComponent(ComponentIds.Level, component);
            if (previousComponent != null) {
                _levelComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveLevel() {
            var component = level;
            RemoveComponent(ComponentIds.Level);
            _levelComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherLevel;

        public static IMatcher Level {
            get {
                if (_matcherLevel == null) {
                    _matcherLevel = Matcher.AllOf(ComponentIds.Level);
                }

                return _matcherLevel;
            }
        }
    }
}
