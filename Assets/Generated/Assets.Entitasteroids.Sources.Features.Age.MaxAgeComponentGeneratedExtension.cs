using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent maxAge { get { return (Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent)GetComponent(ComponentIds.MaxAge); } }

        public bool hasMaxAge { get { return HasComponent(ComponentIds.MaxAge); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent> _maxAgeComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent>();

        public static void ClearMaxAgeComponentPool() {
            _maxAgeComponentPool.Clear();
        }

        public Entity AddMaxAge(float newMaxAge) {
            var component = _maxAgeComponentPool.Count > 0 ? _maxAgeComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent();
            component.maxAge = newMaxAge;
            return AddComponent(ComponentIds.MaxAge, component);
        }

        public Entity ReplaceMaxAge(float newMaxAge) {
            var previousComponent = hasMaxAge ? maxAge : null;
            var component = _maxAgeComponentPool.Count > 0 ? _maxAgeComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent();
            component.maxAge = newMaxAge;
            ReplaceComponent(ComponentIds.MaxAge, component);
            if (previousComponent != null) {
                _maxAgeComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMaxAge() {
            var component = maxAge;
            RemoveComponent(ComponentIds.MaxAge);
            _maxAgeComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMaxAge;

        public static IMatcher MaxAge {
            get {
                if (_matcherMaxAge == null) {
                    _matcherMaxAge = Matcher.AllOf(ComponentIds.MaxAge);
                }

                return _matcherMaxAge;
            }
        }
    }
}
