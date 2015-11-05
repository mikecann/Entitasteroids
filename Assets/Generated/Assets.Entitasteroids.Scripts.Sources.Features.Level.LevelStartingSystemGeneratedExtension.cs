namespace Entitas {
    public partial class Pool {
        public ISystem CreateLevelStartingSystem() {
            return this.CreateSystem<Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelStartingSystem>();
        }
    }
}