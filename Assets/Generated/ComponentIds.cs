public static class ComponentIds {
    public const int Bounds = 0;
    public const int WrappedAroundGameBounds = 1;
    public const int Asteroid = 2;
    public const int Camera = 3;
    public const int Hitpoints = 4;
    public const int Fireable = 5;
    public const int Level = 6;
    public const int Lives = 7;
    public const int Collision = 8;
    public const int CollisionRadius = 9;
    public const int Score = 10;
    public const int SpaceshipDeathroes = 11;
    public const int WaitingForSpace = 12;
    public const int Tick = 13;
    public const int View = 14;
    public const int Age = 15;
    public const int MaxAge = 16;
    public const int Bullet = 17;
    public const int Destroying = 18;
    public const int Game = 19;
    public const int Playing = 20;
    public const int Gun = 21;
    public const int Controllable = 22;
    public const int Input = 23;
    public const int Force = 24;
    public const int Rigidbody = 25;
    public const int Player = 26;
    public const int Position = 27;
    public const int Resource = 28;
    public const int Rotation = 29;
    public const int Spaceship = 30;

    public const int TotalComponents = 31;

    public static readonly string[] componentNames = {
        "Bounds",
        "WrappedAroundGameBounds",
        "Asteroid",
        "Camera",
        "Hitpoints",
        "Fireable",
        "Level",
        "Lives",
        "Collision",
        "CollisionRadius",
        "Score",
        "SpaceshipDeathroes",
        "WaitingForSpace",
        "Tick",
        "View",
        "Age",
        "MaxAge",
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
        typeof(Assets.Entitasteroids.Scripts.Sources.Bounds.BoundsComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Bounds.WrappedAroundGameBoundsComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Asteroid.AsteroidComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Damage.HitpointsComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Gun.FireableComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Level.LevelComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Lives.LivesComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Physics.CollisionRadiusComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.SpaceshipDeathroesComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Spaceship.WaitingForSpaceComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.Tick.TickComponent),
        typeof(Assets.Entitasteroids.Scripts.Sources.Features.View.ViewComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Age.AgeComponent),
        typeof(Assets.Entitasteroids.Sources.Features.Age.MaxAgeComponent),
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