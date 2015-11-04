using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Physics
{
    public class AddRigidbodySystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var rigidbody = entity.view.gameObject.GetComponent<Rigidbody2D>();
                if (rigidbody != null)
                    entity.AddRigidbody(rigidbody);
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.View.OnEntityAdded(); }
        }
    }
}
