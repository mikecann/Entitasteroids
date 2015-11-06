using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class CollisionsController : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D coll)
        {
            Pools.pool.CreateCollision(coll);
        }
    }
}
