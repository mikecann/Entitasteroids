using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Bullets
{
    public class BulletCollisionSystem : IReactiveSystem, ISetPool
    {
        private Group _bullets;
        private Group _damageable;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                var obj = entity.collision.collision.gameObject;
                var bullet = _bullets.GetEntities().FirstOrDefault(e => e.view.gameObject == obj);

                if (bullet != null)
                    Collide(bullet, entity.collision.collision.contacts);
            }
        }

        private void Collide(Entity bullet, ContactPoint2D[] contacts)
        {
            foreach (var contact in contacts)
            {
                var damageable = _damageable.GetEntities().FirstOrDefault(e => e != bullet &&
                                             e.view.gameObject == contact.otherCollider.gameObject);

                if (damageable != null)
                {
                    damageable.ReplaceHitpoints(damageable.hitpoints.hp - 1);
                    bullet.isDestroying = true;
                }
            }
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.Collision.OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _bullets = pool.GetGroup(Matcher.AllOf(Matcher.Bullet, Matcher.View));
            _damageable = pool.GetGroup(Matcher.AllOf(Matcher.Hitpoints, Matcher.View));
        }
    }
}
