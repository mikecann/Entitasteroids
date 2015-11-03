namespace Entitas {
    public partial class Pool {
        public ISystem CreateMaxAgeSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Age.MaxAgeSystem>();
        }
    }
}