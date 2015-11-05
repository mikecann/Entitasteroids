using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Bounds
{
    public class GameBoundsUpdatingSystem : IReactiveSystem, ISetPool
    {
        private Group _games;

        public void Execute(List<Entity> entities)
        {
            foreach (var entity in entities)
                UpdateBounds(entity.camera.camera);
        }

        private void UpdateBounds(Camera cam)
        {
            var size = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            var bounds = new UnityEngine.Bounds(Vector3.zero, new Vector3(size.x * 2, size.y * 2));

            foreach (var entity in _games.GetEntities())
                entity.ReplaceBounds(bounds);
        }

        public TriggerOnEvent trigger
        {
            get { return Matcher.AllOf(Matcher.Camera).OnEntityAdded(); }
        }

        public void SetPool(Pool pool)
        {
            _games = pool.GetGroup(Matcher.AllOf(Matcher.Game, Matcher.Bounds));
        }
    }
}
