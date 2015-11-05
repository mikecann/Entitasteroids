using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Scripts.Sources.Features.Asteroid;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Level
{
    public class LevelStartingSystem : IReactiveSystem, ISetPool
    {
        private Pool _pool;
        private Group _games;
        private Group _collideables;

        public void Execute(List<Entity> entities)
        {
            var game = _games.GetSingleEntity();
            if (game == null || !game.isPlaying)
                return;

            foreach (var entity in entities)
                StartLevel(entity.level.level, game);
        }

        private void StartLevel(int level, Entity game)
        {
            _pool.CreatePlayer(true);
            for (var i = 0; i < level+1; i++)
                CreateAsteroid(game);
        }

        private void CreateAsteroid(Entity game)
        {
            var size = Asteroid.AsteroidSize.Large;
            _pool.CreateAsteroid(0, 0, size)
                .FindEmptyPosition(AsteroidData.Radii[size], game.bounds.bounds, _collideables.GetEntities());
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Level).OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _games = pool.GetGroup(Matcher.Game);
            _collideables = pool.GetGroup(Matcher.AllOf(Matcher.CollisionRadius, Matcher.Position));
        }
    }
}
