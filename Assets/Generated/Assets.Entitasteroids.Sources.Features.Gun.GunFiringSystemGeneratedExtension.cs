namespace Entitas {
    public partial class Pool {
        public ISystem CreateGunFiringSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Gun.GunFiringSystem>();
        }
    }
}