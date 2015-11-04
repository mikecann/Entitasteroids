namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Destroy.DestroyingComponent destroyingComponent = new Assets.Entitasteroids.Sources.Features.Destroy.DestroyingComponent();

        public bool isDestroying {
            get { return HasComponent(ComponentIds.Destroying); }
            set {
                if (value != isDestroying) {
                    if (value) {
                        AddComponent(ComponentIds.Destroying, destroyingComponent);
                    } else {
                        RemoveComponent(ComponentIds.Destroying);
                    }
                }
            }
        }

        public Entity IsDestroying(bool value) {
            isDestroying = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDestroying;

        public static IMatcher Destroying {
            get {
                if (_matcherDestroying == null) {
                    _matcherDestroying = Matcher.AllOf(ComponentIds.Destroying);
                }

                return _matcherDestroying;
            }
        }
    }
}
