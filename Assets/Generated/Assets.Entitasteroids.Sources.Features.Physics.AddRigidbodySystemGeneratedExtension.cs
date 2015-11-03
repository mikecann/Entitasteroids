namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddRigidbodySystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Physics.AddRigidbodySystem>();
        }
    }
}