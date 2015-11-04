public static class ComponentIds {
    public const int Fireable = 0;
    public const int Tick = 1;
    public const int View = 2;
    public const int Age = 3;
    public const int MaxAge = 4;
    public const int Asteroid = 5;
    public const int Bullet = 6;
    public const int Destroying = 7;
    public const int Game = 8;
    public const int Playing = 9;
    public const int Gun = 10;
    public const int Controllable = 11;
    public const int Input = 12;
    public const int Force = 13;
    public const int Rigidbody = 14;
    public const int Player = 15;
    public const int Position = 16;
    public const int Resource = 17;
    public const int Rotation = 18;
    public const int Spaceship = 19;

    public const int TotalComponents = 20;

    public static readonly string[] componentNames = {
        "Fireable",
        "Tick",
        "View",
        "Age",
        "MaxAge",
        "Asteroid",
        "Bullet",
        "Destroying",
        "Game",
        "Playing",
        "Gun",
        "Controllable",
        "Input",
        "Force",
        "Rigidbody",
        "Player",
        "Position",
        "Resource",
        "Rotation",
        "Spaceship"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Gun.FireableComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.View.ViewComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Age.AgeComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Asteroids.AsteroidComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Bullets.BulletComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Destroy.DestroyingComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Game.GameComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Game.PlayingComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Gun.GunComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Input.ControllableComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Input.InputComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Physics.ForceComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Physics.RigidbodyComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Player.Player),
        typeof(Assets.Entitasteroids.Sources.Features.Position.PositionComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Resources.ResourceComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Rotation.RotationComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Spaceship.SpaceshipComponent)
    };
}