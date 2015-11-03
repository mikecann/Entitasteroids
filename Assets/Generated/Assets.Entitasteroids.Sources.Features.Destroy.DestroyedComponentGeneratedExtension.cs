namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Destroy.DestroyedComponent destroyedComponent = new Assets.Entitasteroids.Sources.Features.Destroy.DestroyedComponent();

        public bool isDestroyed {
            get { return HasComponent(ComponentIds.Destroyed); }
            set {
                if (value != isDestroyed) {
                    if (value) {
                        AddComponent(ComponentIds.Destroyed, destroyedComponent);
                    } else {
                        RemoveComponent(ComponentIds.Destroyed);
                    }
                }
            }
        }

        public Entity IsDestroyed(bool value) {
            isDestroyed = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDestroyed;

        public static IMatcher Destroyed {
            get {
                if (_matcherDestroyed == null) {
                    _matcherDestroyed = Matcher.AllOf(ComponentIds.Destroyed);
                }

                return _matcherDestroyed;
            }
        }
    }
}
