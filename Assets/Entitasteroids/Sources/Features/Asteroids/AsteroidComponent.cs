using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Asteroids
{
    public enum AsteroidSize
    {
        Large,
        Medium,
        Small,
        Tiny
    }

    public class AsteroidComponent : IComponent
    {
        public AsteroidSize size;
    }
}
