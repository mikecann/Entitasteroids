namespace Entitas {
    public partial class Pool {
        public ISystem CreateInputDestructionSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Sources.Features.Input.InputDestructionSystem>();
        }
    }
}