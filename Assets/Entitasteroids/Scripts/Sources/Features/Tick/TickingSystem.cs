using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Sources.Features.Tick
{
    public class TickingSystem : IExecuteSystem, ISetPool
    {
        private Pool _pool;

        public void Execute()
        {
            _pool.CreateTick(Time.deltaTime);
        }

        public void SetPool(Pool pool)
        {
            _pool = pool;
        }
    }
}
