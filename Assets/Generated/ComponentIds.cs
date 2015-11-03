public static class ComponentIds {
    public const int Age = 0;
    public const int MaxAge = 1;
    public const int Asteroid = 2;
    public const int Bullet = 3;
    public const int Destroyed = 4;
    public const int Game = 5;
    public const int Playing = 6;
    public const int Gun = 7;
    public const int Controllable = 8;
    public const int Input = 9;
    public const int Rigidbody = 10;
    public const int Player = 11;
    public const int Position = 12;
    public const int Resource = 13;
    public const int View = 14;
    public const int Rotation = 15;
    public const int Spaceship = 16;

    public const int TotalComponents = 17;

    public static readonly string[] componentNames = {
        "Age",
        "MaxAge",
        "Asteroid",
        "Bullet",
        "Destroyed",
        "Game",
        "Playing",
        "Gun",
        "Controllable",
        "Input",
        "Rigidbody",
        "Player",
        "Position",
        "Resource",
        "View",
        "Rotation",
        "Spaceship"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Entitasteroids.Sources.Features.Age.AgeComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Bullets.BulletComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Destroy.DestroyedComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Game.GameComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Game.PlayingComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Gun.GunComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Input.ControllableComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Input.InputComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Player.Player),
        typeof(Assets.Entitasteroids.Sources.Features.Position.PositionComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Resources.ResourceComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Resources.ViewComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent)
    };
}