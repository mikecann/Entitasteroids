using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Physics
{
    public class RenderForceSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                ApplyForces(entity);
                ApplyTorque(entity);

                entity.force.torque = 0;
                entity.force.relativeForces.Clear();
            }
        }

        private void ApplyTorque(Entity entity)
        {
            entity.rigidbody.rigidbody.AddTorque(entity.force.torque, UnityEngine.ForceMode2D.Impulse);
        }

        private void ApplyForces(Entity entity)
        {
            foreach (var force in entity.force.relativeForces)
                entity.rigidbody.rigidbody.AddRelativeForce(force, UnityEngine.ForceMode2D.Impulse);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Force, Matcher.Rigidbody).OnEntityAdded(); }
        }
    }
}
