using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Age.AgeComponent age { get { return (Assets.Entitasteroids.Sources.Features.Age.AgeComponent)GetComponent(ComponentIds.Age); } }

        public bool hasAge { get { return HasComponent(ComponentIds.Age); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Age.AgeComponent> _ageComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Age.AgeComponent>();

        public static void ClearAgeComponentPool() {
            _ageComponentPool.Clear();
        }

        public Entity AddAge(float newAge) {
            var component = _ageComponentPool.Count > 0 ? _ageComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Age.AgeComponent();
            component.age = newAge;
            return AddComponent(ComponentIds.Age, component);
        }

        public Entity ReplaceAge(float newAge) {
            var previousComponent = hasAge ? age : null;
            var component = _ageComponentPool.Count > 0 ? _ageComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Age.AgeComponent();
            component.age = newAge;
            ReplaceComponent(ComponentIds.Age, component);
            if (previousComponent != null) {
                _ageComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveAge() {
            var component = age;
            RemoveComponent(ComponentIds.Age);
            _ageComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAge;

        public static IMatcher Age {
            get {
                if (_matcherAge == null) {
                    _matcherAge = Matcher.AllOf(ComponentIds.Age);
                }

                return _matcherAge;
            }
        }
    }
}
