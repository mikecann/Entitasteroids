namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Game.GameComponent gameComponent = new Assets.Entitasteroids.Sources.Features.Game.GameComponent();

        public bool isGame {
            get { return HasComponent(ComponentIds.Game); }
            set {
                if (value != isGame) {
                    if (value) {
                        AddComponent(ComponentIds.Game, gameComponent);
                    } else {
                        RemoveComponent(ComponentIds.Game);
                    }
                }
            }
        }

        public Entity IsGame(bool value) {
            isGame = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGame;

        public static IMatcher Game {
            get {
                if (_matcherGame == null) {
                    _matcherGame = Matcher.AllOf(ComponentIds.Game);
                }

                return _matcherGame;
            }
        }
    }
}
