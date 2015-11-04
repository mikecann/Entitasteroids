using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent tick { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent)GetComponent(ComponentIds.Tick); } }

        public bool hasTick { get { return HasComponent(ComponentIds.Tick); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent> _tickComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent>();

        public static void ClearTickComponentPool() {
            _tickComponentPool.Clear();
        }

        public Entity AddTick(float newDelta) {
            var component = _tickComponentPool.Count > 0 ? _tickComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent();
            component.delta = newDelta;
            return AddComponent(ComponentIds.Tick, component);
        }

        public Entity ReplaceTick(float newDelta) {
            var previousComponent = hasTick ? tick : null;
            var component = _tickComponentPool.Count > 0 ? _tickComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent();
            component.delta = newDelta;
            ReplaceComponent(ComponentIds.Tick, component);
            if (previousComponent != null) {
                _tickComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTick() {
            var component = tick;
            RemoveComponent(ComponentIds.Tick);
            _tickComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTick;

        public static IMatcher Tick {
            get {
                if (_matcherTick == null) {
                    _matcherTick = Matcher.AllOf(ComponentIds.Tick);
                }

                return _matcherTick;
            }
        }
    }
}
