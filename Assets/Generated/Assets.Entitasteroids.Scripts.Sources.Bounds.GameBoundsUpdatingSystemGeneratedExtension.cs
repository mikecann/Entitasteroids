namespace Entitas {
    public partial class Pool {
        public ISystem CreateGameBoundsUpdatingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Bounds.GameBoundsUpdatingSystem>();
        }
    }
}