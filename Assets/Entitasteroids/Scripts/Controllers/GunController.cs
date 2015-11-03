using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class GunController : MonoBehaviour
    {
        void Start()
        {
            Pools.pool.CreateGun(gameObject);
        }
    }
}
