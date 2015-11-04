namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderForceSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Physics.RenderForceSystem>();
        }
    }
}