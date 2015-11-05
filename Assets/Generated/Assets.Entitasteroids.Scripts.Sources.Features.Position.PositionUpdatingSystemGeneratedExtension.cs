namespace Entitas {
    public partial class Pool {
        public ISystem CreatePositionUpdatingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Position.PositionUpdatingSystem>();
        }
    }
}