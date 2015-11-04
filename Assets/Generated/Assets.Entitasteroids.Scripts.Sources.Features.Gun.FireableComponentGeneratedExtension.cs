namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Scripts.Sources.Features.Gun.FireableComponent fireableComponent = new Assets.Entitasteroids.Scripts.Sources.Features.Gun.FireableComponent();

        public bool isFireable {
            get { return HasComponent(ComponentIds.Fireable); }
            set {
                if (value != isFireable) {
                    if (value) {
                        AddComponent(ComponentIds.Fireable, fireableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Fireable);
                    }
                }
            }
        }

        public Entity IsFireable(bool value) {
            isFireable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFireable;

        public static IMatcher Fireable {
            get {
                if (_matcherFireable == null) {
                    _matcherFireable = Matcher.AllOf(ComponentIds.Fireable);
                }

                return _matcherFireable;
            }
        }
    }
}
