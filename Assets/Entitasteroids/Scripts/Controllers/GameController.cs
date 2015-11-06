using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Scripts.Sources.Bounds;
using Assets.Entitasteroids.Scripts.Sources.Features.Asteroid;
using Assets.Entitasteroids.Scripts.Sources.Features.Bullets;
using Assets.Entitasteroids.Scripts.Sources.Features.Gun;
using Assets.Entitasteroids.Scripts.Sources.Features.Level;
using Assets.Entitasteroids.Scripts.Sources.Features.Position;
using Assets.Entitasteroids.Scripts.Sources.Features.Tick;
using Assets.Entitasteroids.Scripts.Sources.Features.View;
using Assets.Entitasteroids.Sources.Features.Age;
using Assets.Entitasteroids.Sources.Features.Destroy;
using Assets.Entitasteroids.Sources.Features.Game;
using Assets.Entitasteroids.Sources.Features.Gun;
using Assets.Entitasteroids.Sources.Features.Input;
using Assets.Entitasteroids.Sources.Features.Physics;
using Assets.Entitasteroids.Sources.Features.Player;
using Assets.Entitasteroids.Sources.Features.Position;
using Assets.Entitasteroids.Sources.Features.Resources;
using Assets.Entitasteroids.Sources.Features.Rotation;
using Assets.Entitasteroids.Sources.Features.Spaceship;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;

        void Awake()
        {
            _systems = CreateSystems(Pools.pool);
            _systems.Initialize();

            CreateGame();
            
           
        }

        private void CreateGame()
        {
            var bounds = GetBounds();
            Pools.pool.CreateGame(true, 0, bounds);
        }

        private Bounds GetBounds()
        {
            var size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            return new Bounds(Vector3.zero, new Vector3(size.x * 2, size.y * 2));
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
                .Add(pool.CreateSystem<TickingSystem>())
                .Add(pool.CreateSystem<PositionUpdatingSystem>())
                .Add(pool.CreateSystem<RenderForceSystem>())
                .Add(pool.CreateSystem<BulletCollisionSystem>())
                .Add(pool.CreateSystem<AddViewSystem>())
                .Add(pool.CreateSystem<LevelStartingSystem>())
                .Add(pool.CreateSystem<SpaceshipControlsSystem>())
                .Add(pool.CreateSystem<AddRigidbodySystem>())
                .Add(pool.CreateSystem<AgingSystem>())
                .Add(pool.CreateSystem<MaxAgeSystem>())
                .Add(pool.CreateSystem<AsteroidSplittingSystem>())
                .Add(pool.CreateSystem<RenderRotationSystem>())
                .Add(pool.CreateSystem<GunFiringSystem>())
                .Add(pool.CreateSystem<GunCooldownSystem>())
                .Add(pool.CreateSystem<InputDestructionSystem>())
                .Add(pool.CreateSystem<BoundsWrappingSystem>())
                .Add(pool.CreateSystem<RenderPositionSystem>())
                .Add(pool.CreateSystem<RemoveViewSystem>())
                .Add(pool.CreateSystem<DestroyingSystem>());
        }
    }
}
