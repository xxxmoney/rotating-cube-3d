namespace RotatingCube.Core;

public static class Constants
{
    public const int Framerate = 60;
    public const int DefaultWidth = 800;
    public const int DefaultHeight = 800;
    public const float RotationAcceleration = 0.1f;
    public const float RelativeCubeSize = 0.25f;
    public static readonly Version ApiVersion = new (3, 2);
    public const int CubeSides = 6;
    public static readonly TimeSpan ColorRefreshInterval = TimeSpan.FromMilliseconds(500);
}