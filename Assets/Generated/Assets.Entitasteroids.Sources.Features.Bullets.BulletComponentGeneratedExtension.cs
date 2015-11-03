namespace Entitas {
    public partial class Entity {
        static readonly Assets.Entitasteroids.Sources.Features.Bullets.BulletComponent bulletComponent = new Assets.Entitasteroids.Sources.Features.Bullets.BulletComponent();

        public bool isBullet {
            get { return HasComponent(ComponentIds.Bullet); }
            set {
                if (value != isBullet) {
                    if (value) {
                        AddComponent(ComponentIds.Bullet, bulletComponent);
                    } else {
                        RemoveComponent(ComponentIds.Bullet);
                    }
                }
            }
        }

        public Entity IsBullet(bool value) {
            isBullet = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherBullet;

        public static IMatcher Bullet {
            get {
                if (_matcherBullet == null) {
                    _matcherBullet = Matcher.AllOf(ComponentIds.Bullet);
                }

                return _matcherBullet;
            }
        }
    }
}
