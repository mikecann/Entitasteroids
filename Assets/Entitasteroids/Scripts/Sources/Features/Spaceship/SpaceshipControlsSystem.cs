using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Spaceship
{
    public class SpaceshipControlsSystem : IReactiveSystem, ISetPool
    {
        private Group _spaceships;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.input.accelerate)
                    Accelerate();

                if (entity.input.turnLeft)
                    Rotate(1);

                if (entity.input.turnRight)
                    Rotate(-1);
            }
        }

        private void Rotate(int direction)
        {
            foreach (var entity in _spaceships.GetEntities())
            {
                var relativeForces = entity.force.relativeForces;
                var torque = entity.force.torque + entity.spaceship.rotationRate*direction;
                entity.ReplaceForce(relativeForces, torque);
            }
        }

        private void Accelerate()
        {
            foreach (var entity in _spaceships.GetEntities())
            {
                var relativeForces = entity.force.relativeForces;
                relativeForces.Add(new Vector2(0, entity.spaceship.accelerationRate));
                var torque = entity.force.torque;
                entity.ReplaceForce(relativeForces, torque);
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Input.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _spaceships = pool.GetGroup(Matcher.AllOf(Matcher.Spaceship, Matcher.Controllable,
                Matcher.Force));
        }
    }
}
