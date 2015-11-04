using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Sources.Features.Physics
{
    public class ForceComponent : IComponent
    {
        public List<Vector2> relativeForces;
        public float torque;
    }
}
