using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Scripts;
using Assets.Entitasteroids.Scripts.Sources.Features.Asteroid;
using Entitas;
using UnityEngine;

public static class PoolExtensions
{
    public static Entity CreatePlayer(this Pool pool, bool controllable)
    {
        return pool.CreateEntity()
            .IsPlayer(true)
            .AddPosition(0, 0)
            .AddSpaceship(0.5f, 0.02f)
            .AddCollisionRadius(1)
            .IsControllable(controllable)
            .IsWrappedAroundGameBounds(true)
            .AddForce(new List<Vector2>(), 0)
            .AddResource("Prefabs/Spaceship");
    }

    public static Entity CreateGame(this Pool pool, bool playing, int level, Bounds bounds)
    {
        return pool.CreateEntity()
            .IsGame(true)
            .AddBounds(bounds)
            .AddLevel(level)
            .AddLives(3)
            .AddScore(0)
            .IsPlaying(playing);
    }

    public static Entity CreateBullet(this Pool pool, float x, float y, float rotation)
    {
        return pool.CreateEntity()
            .IsBullet(true)
            .AddPosition(x, y)
            .AddRotation(rotation)
            .AddAge(0)
            .AddMaxAge(1f)
            .IsWrappedAroundGameBounds(true)
            .AddForce(new List<Vector2> { new Vector2(0, 10) }, 0)
            .AddResource("Prefabs/Bullet");
    }

    public static Entity CreateGun(this Pool pool, GameObject view)
    {
        return pool.CreateEntity()
            .AddGun(0.3f, 0)
            .IsControllable(true)
            .IsFireable(true)
            .AddView(view);
    }

    public static Entity CreateTick(this Pool pool, float delta)
    {
        return pool.CreateEntity()
            .AddTick(delta)
            .IsDestroying(true); 
    }

    public static Entity CreateCamera(this Pool pool, Camera camera)
    {
        return pool.CreateEntity()
            .AddCamera(camera);
    }

    public static Entity CreateAsteroid(this Pool pool, float x, float y, AsteroidSize size)
    {
        return pool.CreateEntity()
            .AddAsteroid(size)
            .AddPosition(x, y)
            .AddHitpoints(1)
            .AddCollisionRadius(AsteroidData.Radii[size])
            .IsWrappedAroundGameBounds(true)
            .AddResource("Prefabs/" + AsteroidData.Resources[size]);
    }

    public static Entity CreateCollision(this Pool pool, Collision2D collision)
    {
        return pool.CreateEntity()
            .AddCollision(collision)
            .IsDestroying(true);

    }

    public static Entity CreateAsteroidDebrisEffect(this Pool pool, float x, float y)
    {
        return pool.CreateEntity()
            .AddResource("Prefabs/Asteroid Debris Effect")
            .AddAge(0)
            .AddPosition(x, y)
            .AddMaxAge(3);

    }

    public static Entity CreateSpaceshipExplosionEffect(this Pool pool, float x, float y)
    {
        return pool.CreateEntity()
            .AddResource("Prefabs/Spaceship Explosion Effect")
            .AddAge(0)
            .AddPosition(x, y)
            .AddMaxAge(3);

    }
}