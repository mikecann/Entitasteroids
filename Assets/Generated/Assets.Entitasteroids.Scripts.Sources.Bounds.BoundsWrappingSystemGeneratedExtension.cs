namespace Entitas {
    public partial class Pool {
        public ISystem CreateBoundsWrappingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsWrappingSystem>();
        }
    }
}