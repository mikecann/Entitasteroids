namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Game.PlayingComponent playingComponent = new Assets.Entitasteroids.Sources.Features.Game.PlayingComponent();

        public bool isPlaying {
            get { return HasComponent(ComponentIds.Playing); }
            set {
                if (value != isPlaying) {
                    if (value) {
                        AddComponent(ComponentIds.Playing, playingComponent);
                    } else {
                        RemoveComponent(ComponentIds.Playing);
                    }
                }
            }
        }

        public Entity IsPlaying(bool value) {
            isPlaying = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPlaying;

        public static IMatcher Playing {
            get {
                if (_matcherPlaying == null) {
                    _matcherPlaying = Matcher.AllOf(ComponentIds.Playing);
                }

                return _matcherPlaying;
            }
        }
    }
}
