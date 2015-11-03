using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Gun
{
    public class GunFiringSystem : IReactiveSystem, ISetPool
    {
        private Group _guns;
        private Pool _pool;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.input.fire)
                    Fire();
            }
        }

        private void Fire()
        {
            foreach (var entity in _guns.GetEntities())
            {
                var pos = entity.view.gameObject.transform.position;
                var rot = entity.view.gameObject.transform.rotation.eulerAngles.z;
                _pool.CreateBullet(pos.x, pos.y, rot);
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Input.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
            _guns = pool.GetGroup(Matcher.AllOf(Matcher.Gun, Matcher.Controllable, Matcher.View));
        }
    }
}
