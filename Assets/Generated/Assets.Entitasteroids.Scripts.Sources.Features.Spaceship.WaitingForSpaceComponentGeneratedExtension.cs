namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.WaitingForSpaceComponent waitingForSpaceComponent = new Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.WaitingForSpaceComponent();

        public bool isWaitingForSpace {
            get { return HasComponent(ComponentIds.WaitingForSpace); }
            set {
                if (value != isWaitingForSpace) {
                    if (value) {
                        AddComponent(ComponentIds.WaitingForSpace, waitingForSpaceComponent);
                    } else {
                        RemoveComponent(ComponentIds.WaitingForSpace);
                    }
                }
            }
        }

        public Entity IsWaitingForSpace(bool value) {
            isWaitingForSpace = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherWaitingForSpace;

        public static IMatcher WaitingForSpace {
            get {
                if (_matcherWaitingForSpace == null) {
                    _matcherWaitingForSpace = Matcher.AllOf(ComponentIds.WaitingForSpace);
                }

                return _matcherWaitingForSpace;
            }
        }
    }
}
