namespace Entitas {
    public partial class Pool {
        public ISystem CreateAgingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Age.AgingSystem>();
        }
    }
}