using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Entitasteroids.Sources.Features.Input
{
    public class InputComponent : IComponent
    {
        public bool accelerate;
        public bool turnLeft;
        public bool turnRight;
        public bool fire;
    }
}
