using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.View
{
    public class AddViewSystem : IReactiveSystem
    {
        readonly Transform _viewContainer = new GameObject("Views").transform;

        public void Execute(List<Entity> entities)
        {
            foreach (var e in entities)
            {
                var res = UnityEngine.Resources.Load<GameObject>(e.resource.name);
                GameObject gameObject = null;
                try
                {
                    gameObject = UnityEngine.Object.Instantiate(res);
                }
                catch (Exception)
                {
                    Debug.Log("Cannot instantiate " + res);
                }

                if (gameObject != null)
                {
                    gameObject.transform.SetParent(_viewContainer, false);
                    e.AddView(gameObject);

                    if (e.hasPosition)
                        gameObject.transform.position = new Vector3(e.position.x, e.position.y);
                }
            }
        }

        public TriggerOnEvent trigger {
            get { return Matcher.Resource.OnEntityAdded(); }
        }
    }
}
