namespace Entitas {
    public partial class Pool {
        public ISystem CreatePlayerSpawningSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Player.PlayerSpawningSystem>();
        }
    }
}