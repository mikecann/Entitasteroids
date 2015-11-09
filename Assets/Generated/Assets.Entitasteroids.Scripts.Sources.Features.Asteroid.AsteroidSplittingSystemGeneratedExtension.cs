namespace Entitas {
    public partial class Pool {
        public ISystem CreateAsteroidSplittingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Asteroid.AsteroidSplittingSystem>();
        }
    }
}