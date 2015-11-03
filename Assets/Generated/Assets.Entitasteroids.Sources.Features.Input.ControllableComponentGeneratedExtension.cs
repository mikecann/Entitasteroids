namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Input.ControllableComponent controllableComponent = new Assets.Entitasteroids.Sources.Features.Input.ControllableComponent();

        public bool isControllable {
            get { return HasComponent(ComponentIds.Controllable); }
            set {
                if (value != isControllable) {
                    if (value) {
                        AddComponent(ComponentIds.Controllable, controllableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Controllable);
                    }
                }
            }
        }

        public Entity IsControllable(bool value) {
            isControllable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherControllable;

        public static IMatcher Controllable {
            get {
                if (_matcherControllable == null) {
                    _matcherControllable = Matcher.AllOf(ComponentIds.Controllable);
                }

                return _matcherControllable;
            }
        }
    }
}
