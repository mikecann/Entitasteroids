using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Sources.Features.Age;
using Assets.Entitasteroids.Sources.Features.Destroy;
using Assets.Entitasteroids.Sources.Features.Game;
using Assets.Entitasteroids.Sources.Features.Gun;
using Assets.Entitasteroids.Sources.Features.Input;
using Assets.Entitasteroids.Sources.Features.Physics;
using Assets.Entitasteroids.Sources.Features.Player;
using Assets.Entitasteroids.Sources.Features.Position;
using Assets.Entitasteroids.Sources.Features.Rendering;
using Assets.Entitasteroids.Sources.Features.Rotation;
using Assets.Entitasteroids.Sources.Features.Spaceship;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        public Prefabs prefabs;

        private Systems _systems;

        void Start()
        {
            PoolExtensions.prefabs = prefabs;

            _systems = CreateSystems(Pools.pool);
            _systems.Initialize();
        }

        void Update()
        {
            _systems.Execute();
        }

        private Systems CreateSystems(Pool pool)
        {
#if (UNITY_EDITOR)
            return new DebugSystems()
#else
        return new Systems()
#endif
                .Add(pool.CreateSystem<GameStartSystem>())
                .Add(pool.CreateSystem<AddViewSystem>())
                .Add(pool.CreateSystem<PlayerSpawningSystem>())
                .Add(pool.CreateSystem<SpaceshipControlsSystem>())
                .Add(pool.CreateSystem<AddRigidbodySystem>())
                .Add(pool.CreateSystem<DestroyingSystem>())
                .Add(pool.CreateSystem<MaxAgeSystem>())
                .Add(pool.CreateSystem<RenderRotationSystem>())
                .Add(pool.CreateSystem<GunFiringSystem>())
                .Add(pool.CreateSystem<InputDestructionSystem>())
                .Add(pool.CreateSystem<RenderPositionSystem>());
        }
    }
}
