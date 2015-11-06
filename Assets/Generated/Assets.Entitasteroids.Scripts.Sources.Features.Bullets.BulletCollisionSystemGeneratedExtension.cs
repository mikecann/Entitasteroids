namespace Entitas {
    public partial class Pool {
        public ISystem CreateBulletCollisionSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Bullets.BulletCollisionSystem>();
        }
    }
}