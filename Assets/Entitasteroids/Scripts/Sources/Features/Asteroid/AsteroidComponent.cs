using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Asteroid
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
