namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderPositionSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Position.RenderPositionSystem>();
        }
    }
}