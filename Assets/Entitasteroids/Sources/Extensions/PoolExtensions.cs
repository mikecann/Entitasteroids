using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Entitasteroids.Scripts;
using Entitas;
using UnityEngine;

public static class PoolExtensions
{
    public static Prefabs prefabs;

    public static Entity CreatePlayer(this Pool pool, bool controllable)
    {
        return pool.CreateEntity()
            .IsPlayer(true)
            .AddPosition(0, 0)
            .AddSpaceship(14, 10)
            .IsControllable(controllable)
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
            .AddResource("Prefabs/Bullet");
    }

    public static Entity CreateGun(this Pool pool, GameObject view)
    {
        return pool.CreateEntity()
            .IsGun(true)
            .IsControllable(true)
            .AddView(view);
    }
}