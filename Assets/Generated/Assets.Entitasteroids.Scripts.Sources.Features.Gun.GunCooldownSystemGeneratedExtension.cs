namespace Entitas {
    public partial class Pool {
        public ISystem CreateGunCooldownSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Gun.GunCooldownSystem>();
        }
    }
}