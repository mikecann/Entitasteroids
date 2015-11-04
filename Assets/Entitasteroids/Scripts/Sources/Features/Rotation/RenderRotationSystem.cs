using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Rotation
{
    public class RenderRotationSystem : IReactiveSystem
    {
        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var r = entity.view.gameObject.transform.rotation.eulerAngles;
                entity.view.gameObject.transform.rotation = Quaternion.Euler(r.x, r.y, entity.rotation.rotation);
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Rotation, Matcher.View).OnEntityAdded(); }
        }
    }
}
