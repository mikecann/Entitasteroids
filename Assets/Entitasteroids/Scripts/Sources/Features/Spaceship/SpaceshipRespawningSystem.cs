using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Spaceship
{
    public class SpaceshipRespawningSystem : IExecuteSystem, ISetPool
    {
        private Pool _pool;
        private Group _games;
        private Group _asteroids;
        private Group _waiting;
        private Group _lives;

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _pool.GetGroup(Matcher.SpaceshipDeathroes).OnEntityRemoved += OnDeaththroesRemoved;
            _waiting = _pool.GetGroup(Matcher.AllOf(Matcher.WaitingForSpace, Matcher.Spaceship));
            _asteroids = pool.GetGroup(Matcher.AllOf(Matcher.Asteroid, Matcher.CollisionRadius));
            _games = _pool.GetGroup(Matcher.AllOf(Matcher.Game, Matcher.Bounds));
            _lives = _pool.GetGroup(Matcher.Lives);
        }

        private void OnDeaththroesRemoved(Group group, Entity entity, int index, IComponent component)
        {
            if (_lives.GetSingleEntity().lives.lives == 0)
                return;

            _pool.CreateEntity()
                .AddSpaceship(0.5f, 0.02f)
                .AddCollisionRadius(5)
                .IsWaitingForSpace(true);
        }

        public void Execute()
        {
            var game = _games.GetSingleEntity();
            if (game == null)
                return;

            var bounds = game.bounds.bounds;
            foreach (var entity in _waiting.GetEntities())
            {
                var pos = bounds.RandomPosition();
                if (HasSpace(pos, entity))
                    Respawn(entity);
            }
        }

        private void Respawn(Entity entity)
        {
            _pool.CreatePlayer(true);
            entity.isDestroying = true;
        }

        private bool HasSpace(Vector2 pos, Entity entity)
        {
            return entity.CollidesWithOthers(pos, _asteroids.GetEntities());
        }
    }
}
