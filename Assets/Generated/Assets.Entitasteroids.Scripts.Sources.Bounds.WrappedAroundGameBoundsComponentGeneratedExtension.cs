namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Scripts.Sources.Bounds.WrappedAroundGameBoundsComponent wrappedAroundGameBoundsComponent = new Assets.Entitasteroids.Scripts.Sources.Bounds.WrappedAroundGameBoundsComponent();

        public bool isWrappedAroundGameBounds {
            get { return HasComponent(ComponentIds.WrappedAroundGameBounds); }
            set {
                if (value != isWrappedAroundGameBounds) {
                    if (value) {
                        AddComponent(ComponentIds.WrappedAroundGameBounds, wrappedAroundGameBoundsComponent);
                    } else {
                        RemoveComponent(ComponentIds.WrappedAroundGameBounds);
                    }
                }
            }
        }

        public Entity IsWrappedAroundGameBounds(bool value) {
            isWrappedAroundGameBounds = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherWrappedAroundGameBounds;

        public static IMatcher WrappedAroundGameBounds {
            get {
                if (_matcherWrappedAroundGameBounds == null) {
                    _matcherWrappedAroundGameBounds = Matcher.AllOf(ComponentIds.WrappedAroundGameBounds);
                }

                return _matcherWrappedAroundGameBounds;
            }
        }
    }
}
