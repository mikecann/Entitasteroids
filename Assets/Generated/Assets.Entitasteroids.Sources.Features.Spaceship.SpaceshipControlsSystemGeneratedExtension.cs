namespace Entitas {
    public partial class Pool {
        public ISystem CreateSpaceshipControlsSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipControlsSystem>();
        }
    }
}