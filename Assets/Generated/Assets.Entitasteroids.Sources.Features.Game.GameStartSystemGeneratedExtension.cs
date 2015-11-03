namespace Entitas {
    public partial class Pool {
        public ISystem CreateGameStartSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Game.GameStartSystem>();
        }
    }
}