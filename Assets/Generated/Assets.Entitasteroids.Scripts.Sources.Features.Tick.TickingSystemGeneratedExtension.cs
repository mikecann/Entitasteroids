namespace Entitas {
    public partial class Pool {
        public ISystem CreateTickingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickingSystem>();
        }
    }
}