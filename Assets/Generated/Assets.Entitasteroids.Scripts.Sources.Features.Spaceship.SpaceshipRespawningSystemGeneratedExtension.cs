namespace Entitas {
    public partial class Pool {
        public ISystem CreateSpaceshipRespawningSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.SpaceshipRespawningSystem>();
        }
    }
}