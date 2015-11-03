namespace Entitas {
    public partial class Pool {
        public ISystem CreateDestroyingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Destroy.DestroyingSystem>();
        }
    }
}