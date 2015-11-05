using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Position
{
    public class PositionUpdatingSystem : IExecuteSystem, ISetPool
    {
        private Group _positions;

        public void Execute()
        {
            foreach (var entity in _positions.GetEntities())
            {
                var x = entity.view.gameObject.transform.position.x;
                var y = entity.view.gameObject.transform.position.y;
                if (x != entity.position.x || y != entity.position.y)
                    entity.ReplacePosition(x, y);
            }
        }

        public void SetPool(Pool pool)
        {
            _positions = pool.GetGroup(Matcher.AllOf(Matcher.View, Matcher.Position));
        }
    }
}
