using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Asteroid
{
    public static class AsteroidData
    {
        public static Dictionary<AsteroidSize, string> Resources = new Dictionary<AsteroidSize, string>
        {
            {AsteroidSize.Large, "Asteroid Large"},
            {AsteroidSize.Medium, "Asteroid Medium"},
            {AsteroidSize.Small, "Asteroid Small"},
            {AsteroidSize.Tiny, "Asteroid Tiny"}
        };

        public static Dictionary<AsteroidSize, float> Radii = new Dictionary<AsteroidSize, float>
        {
            {AsteroidSize.Large, 1},
            {AsteroidSize.Medium, 0.5f},
            {AsteroidSize.Small, 0.3f},
            {AsteroidSize.Tiny, 0.1f}
        };
    }
}
