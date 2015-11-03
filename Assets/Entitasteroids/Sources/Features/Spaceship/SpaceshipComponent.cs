using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Spaceship
{
    public class SpaceshipComponent : IComponent
    {
        public float accelerationRate;
        public float rotationRate;
    }
}
