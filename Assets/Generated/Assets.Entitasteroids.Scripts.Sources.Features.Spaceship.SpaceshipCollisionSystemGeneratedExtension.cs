namespace Entitas {
    public partial class Pool {
        public ISystem CreateSpaceshipCollisionSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.SpaceshipCollisionSystem>();
        }
    }
}