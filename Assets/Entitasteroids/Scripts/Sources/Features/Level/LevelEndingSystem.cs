using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Level
{
    public class LevelEndingSystem : IReactiveSystem, ISetPool
    {
        private Group _asteroids;
        private Pool _pool;
        private Group _levels;
        private Group _players;

        public void Execute(List<Entity> entities)
        {
            if (_asteroids.count != 0)
                return;

            _pool.CreateEntity()
                .AddAge(0)
                .AddMaxAge(2)
                .OnEntityReleased += OnLevelEndTimerReleased;
        }

        private void OnLevelEndTimerReleased(Entity entity)
        {
            foreach (var player in _players.GetEntities())
                _pool.DestroyEntity(player);

            var lvl = _levels.GetSingleEntity();
            lvl.ReplaceLevel(lvl.level.level + 1);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Asteroid).OnEntityRemoved(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _asteroids = pool.GetGroup(Matcher.Asteroid);
            _levels = pool.GetGroup(Matcher.Level);
            _players = pool.GetGroup(Matcher.Player);
        }
    }
}
