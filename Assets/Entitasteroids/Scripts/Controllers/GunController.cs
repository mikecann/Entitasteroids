using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class GunController : MonoBehaviour
    {
        private Entity _gun;

        void Start()
        {
            _gun = Pools.pool.CreateGun(gameObject);
        }

        void OnDestroy()
        {
            Pools.pool.DestroyEntity(_gun);
        }
    }
}
