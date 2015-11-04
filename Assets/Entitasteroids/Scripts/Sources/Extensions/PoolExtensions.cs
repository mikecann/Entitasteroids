using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Scripts;
using Entitas;
using UnityEngine;

public static class PoolExtensions
{
    public static Entity CreatePlayer(this Pool pool, bool controllable)
    {
        return pool.CreateEntity()
            .IsPlayer(true)
            .AddPosition(0, 0)
            .AddSpaceship(0.5f, 0.2f)
            .IsControllable(controllable)
            .AddForce(new List<Vector2>(), 0)
            .AddResource("Prefabs/Spaceship");
    }

    public static Entity CreateGame(this Pool pool, bool playing)
    {
        return pool.CreateEntity()
            .IsGame(true)
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
            .AddForce(new List<Vector2> { new Vector2(0, 8) }, 0)
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
}