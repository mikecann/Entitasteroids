using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Asteroid
{
    public class AsteroidSplittingSystem : IReactiveSystem, ISetPool
    {
        private Pool _pool;
        private Group _scores;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                if (entity.hitpoints.hp <= 0)
                    Split(entity);
        }

        private void Split(Entity entity)
        {
            entity.isDestroying = true;
            ScorePoints(10);

            _pool.CreateAsteroidDebrisEffect(entity.position.x, entity.position.y);

            if (entity.asteroid.size == AsteroidSize.Tiny)
                return;

            var newSize = AsteroidData.GetNextSizeDown(entity.asteroid.size);
            var newCollisionRadius = AsteroidData.Radii[newSize];
            var randomAngle = UnityEngine.Random.insideUnitCircle.normalized;

            CreateAsteroid(entity, newSize, randomAngle * newCollisionRadius);
            CreateAsteroid(entity, newSize, randomAngle * newCollisionRadius * -1);
        }

        private void ScorePoints(int number)
        {
            var score = _scores.GetSingleEntity();
            score.ReplaceScore(score.score.score + number);
        }

        private void CreateAsteroid(Entity oldAsteroid, AsteroidSize size, Vector2 vec)
        {
            var newAsteroid = _pool.CreateAsteroid(oldAsteroid.position.x + vec.x, 
                oldAsteroid.position.y + vec.y, size);

            ImpartInitialForce(oldAsteroid, newAsteroid, vec);
        }

        private void ImpartInitialForce(Entity oldAsteroid, Entity newAsteroid, Vector2 vec)
        {
            var oldVel = oldAsteroid.rigidbody.rigidbody.velocity;
            var torque = (vec.x + UnityEngine.Random.Range(-1, 1)) * 0.2f;
            newAsteroid.ReplaceForce(new List<Vector2> { vec, oldVel * 0.5f }, torque);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Hitpoints, Matcher.Asteroid).OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _scores = pool.GetGroup(Matcher.Score);
        }
    }
}
