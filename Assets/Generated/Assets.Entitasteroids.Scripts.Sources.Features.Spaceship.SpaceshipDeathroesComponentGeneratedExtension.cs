namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.SpaceshipDeathroesComponent spaceshipDeathroesComponent = new Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.SpaceshipDeathroesComponent();

        public bool isSpaceshipDeathroes {
            get { return HasComponent(ComponentIds.SpaceshipDeathroes); }
            set {
                if (value != isSpaceshipDeathroes) {
                    if (value) {
                        AddComponent(ComponentIds.SpaceshipDeathroes, spaceshipDeathroesComponent);
                    } else {
                        RemoveComponent(ComponentIds.SpaceshipDeathroes);
                    }
                }
            }
        }

        public Entity IsSpaceshipDeathroes(bool value) {
            isSpaceshipDeathroes = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSpaceshipDeathroes;

        public static IMatcher SpaceshipDeathroes {
            get {
                if (_matcherSpaceshipDeathroes == null) {
                    _matcherSpaceshipDeathroes = Matcher.AllOf(ComponentIds.SpaceshipDeathroes);
                }

                return _matcherSpaceshipDeathroes;
            }
        }
    }
}
