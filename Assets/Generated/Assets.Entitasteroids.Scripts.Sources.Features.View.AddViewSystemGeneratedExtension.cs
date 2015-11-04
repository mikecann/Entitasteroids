namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddViewSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.View.AddViewSystem>();
        }
    }
}