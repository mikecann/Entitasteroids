using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Gun
{
    public class GunCooldownSystem : IReactiveSystem, ISetPool
    {
        private Group _guns;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                Cooldown(entity.tick.delta);
        }

        private void Cooldown(float delta)
        {
            foreach (var entity in _guns.GetEntities())
            {
                entity.ReplaceGun(entity.gun.minimumShotInterval, entity.gun.timeSinceLastShot + delta);
                entity.isFireable = entity.gun.timeSinceLastShot >= entity.gun.minimumShotInterval;
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Tick.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _guns = pool.GetGroup(Matcher.AllOf(Matcher.Gun));
        }
    }
}
