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
            {AsteroidSize.Large, 2f},
            {AsteroidSize.Medium, 1.5f},
            {AsteroidSize.Small, 1f},
            {AsteroidSize.Tiny, 0.5f}
        };

        public static AsteroidSize GetNextSizeDown(AsteroidSize size)
        {
            if (size == AsteroidSize.Large)
                return AsteroidSize.Medium;
            if (size == AsteroidSize.Medium)
                return AsteroidSize.Small;
            if (size == AsteroidSize.Small)
                return AsteroidSize.Tiny;

            throw new Exception("Nothing smaller!");
        }
    }
}
