using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Spaceship
{
    public class SpaceshipCollisionSystem : IReactiveSystem, ISetPool
    {
        private Group _spaceships;
        private Pool _pool;
        private Group _lives;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var obj = entity.collision.collision.gameObject;
                var ship = _spaceships.GetEntities().FirstOrDefault(e => e.view.gameObject == obj);

                if (ship != null)
                    Collide(ship);
            }
        }

        private void Collide(Entity ship)
        {
            ship.isDestroying = true;
            DecrementLives();
            _pool.CreateSpaceshipExplosionEffect(ship.position.x, ship.position.y)
                .isSpaceshipDeathroes = true;
        }

        private void DecrementLives()
        {
            var lives = _lives.GetSingleEntity();
            lives.ReplaceLives(lives.lives.lives - 1);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Collision.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _lives = pool.GetGroup(Matcher.Lives);
            _spaceships = pool.GetGroup(Matcher.AllOf(Matcher.Spaceship, Matcher.View));
        }
    }
}
