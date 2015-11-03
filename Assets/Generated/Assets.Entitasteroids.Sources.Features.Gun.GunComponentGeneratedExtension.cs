namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Gun.GunComponent gunComponent = new Assets.Entitasteroids.Sources.Features.Gun.GunComponent();

        public bool isGun {
            get { return HasComponent(ComponentIds.Gun); }
            set {
                if (value != isGun) {
                    if (value) {
                        AddComponent(ComponentIds.Gun, gunComponent);
                    } else {
                        RemoveComponent(ComponentIds.Gun);
                    }
                }
            }
        }

        public Entity IsGun(bool value) {
            isGun = value;
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
