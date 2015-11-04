namespace Entitas {
    public partial class Pool {
        public ISystem CreateRemoveViewSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.View.RemoveViewSystem>();
        }
    }
}