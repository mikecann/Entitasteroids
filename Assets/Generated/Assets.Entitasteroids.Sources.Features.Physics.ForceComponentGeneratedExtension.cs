using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Physics.ForceComponent force { get { return (Assets.Entitasteroids.Sources.Features.Physics.ForceComponent)GetComponent(ComponentIds.Force); } }

        public bool hasForce { get { return HasComponent(ComponentIds.Force); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Physics.ForceComponent> _forceComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Physics.ForceComponent>();

        public static void ClearForceComponentPool() {
            _forceComponentPool.Clear();
        }

        public Entity AddForce(System.Collections.Generic.List<UnityEngine.Vector2> newRelativeForces, float newTorque) {
            var component = _forceComponentPool.Count > 0 ? _forceComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Physics.ForceComponent();
            component.relativeForces = newRelativeForces;
            component.torque = newTorque;
            return AddComponent(ComponentIds.Force, component);
        }

        public Entity ReplaceForce(System.Collections.Generic.List<UnityEngine.Vector2> newRelativeForces, float newTorque) {
            var previousComponent = hasForce ? force : null;
            var component = _forceComponentPool.Count > 0 ? _forceComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Physics.ForceComponent();
            component.relativeForces = newRelativeForces;
            component.torque = newTorque;
            ReplaceComponent(ComponentIds.Force, component);
            if (previousComponent != null) {
                _forceComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveForce() {
            var component = force;
            RemoveComponent(ComponentIds.Force);
            _forceComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherForce;

        public static IMatcher Force {
            get {
                if (_matcherForce == null) {
                    _matcherForce = Matcher.AllOf(ComponentIds.Force);
                }

                return _matcherForce;
            }
        }
    }
}
