using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public Camera cam;

        void Start()
        {
            Pools.pool.CreateCamera(cam);
        }
    }
}
