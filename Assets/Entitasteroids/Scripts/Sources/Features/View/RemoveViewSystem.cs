using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.View
{
    public class RemoveViewSystem : ISetPool, ISystem
    {
        public void SetPool(Pool pool)
        {
            pool.GetGroup(Matcher.View).OnEntityRemoved += OnEntityRemoved;
        }

        private void OnEntityRemoved(Group group, Entity entity, int index, IComponent component)
        {
            var view = (ViewComponent)component;
            Object.Destroy(view.gameObject);
        }
    }
}
