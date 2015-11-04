using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Gun.GunComponent gun { get { return (Assets.Entitasteroids.Sources.Features.Gun.GunComponent)GetComponent(ComponentIds.Gun); } }

        public bool hasGun { get { return HasComponent(ComponentIds.Gun); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Gun.GunComponent> _gunComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Gun.GunComponent>();

        public static void ClearGunComponentPool() {
            _gunComponentPool.Clear();
        }

        public Entity AddGun(float newMinimumShotInterval, float newTimeSinceLastShot) {
            var component = _gunComponentPool.Count > 0 ? _gunComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Gun.GunComponent();
            component.minimumShotInterval = newMinimumShotInterval;
            component.timeSinceLastShot = newTimeSinceLastShot;
            return AddComponent(ComponentIds.Gun, component);
        }

        public Entity ReplaceGun(float newMinimumShotInterval, float newTimeSinceLastShot) {
            var previousComponent = hasGun ? gun : null;
            var component = _gunComponentPool.Count > 0 ? _gunComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Gun.GunComponent();
            component.minimumShotInterval = newMinimumShotInterval;
            component.timeSinceLastShot = newTimeSinceLastShot;
            ReplaceComponent(ComponentIds.Gun, component);
            if (previousComponent != null) {
                _gunComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGun() {
            var component = gun;
            RemoveComponent(ComponentIds.Gun);
            _gunComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGun;

        public static IMatcher Gun {
            get {
                if (_matcherGun == null) {
                    _matcherGun = Matcher.AllOf(ComponentIds.Gun);
                }

                return _matcherGun;
            }
        }
    }
}
