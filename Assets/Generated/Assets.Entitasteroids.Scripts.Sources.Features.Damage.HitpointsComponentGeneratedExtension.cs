using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent hitpoints { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent)GetComponent(ComponentIds.Hitpoints); } }

        public bool hasHitpoints { get { return HasComponent(ComponentIds.Hitpoints); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent> _hitpointsComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent>();

        public static void ClearHitpointsComponentPool() {
            _hitpointsComponentPool.Clear();
        }

        public Entity AddHitpoints(float newHp) {
            var component = _hitpointsComponentPool.Count > 0 ? _hitpointsComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent();
            component.hp = newHp;
            return AddComponent(ComponentIds.Hitpoints, component);
        }

        public Entity ReplaceHitpoints(float newHp) {
            var previousComponent = hasHitpoints ? hitpoints : null;
            var component = _hitpointsComponentPool.Count > 0 ? _hitpointsComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent();
            component.hp = newHp;
            ReplaceComponent(ComponentIds.Hitpoints, component);
            if (previousComponent != null) {
                _hitpointsComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveHitpoints() {
            var component = hitpoints;
            RemoveComponent(ComponentIds.Hitpoints);
            _hitpointsComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherHitpoints;

        public static IMatcher Hitpoints {
            get {
                if (_matcherHitpoints == null) {
                    _matcherHitpoints = Matcher.AllOf(ComponentIds.Hitpoints);
                }

                return _matcherHitpoints;
            }
        }
    }
}
