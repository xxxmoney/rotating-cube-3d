using OpenTK.Mathematics;

namespace RotatingCube.Core.Models;

public class RenderCubeOptions
{
    public float Size { get; init; }
    public Color4 FrontColor { get; init; }
    public Color4 BackColor { get; init; }
    public Color4 TopColor { get; init; }
    public Color4 BottomColor { get; init; }
    public Color4 RightColor { get; init; }
    public Color4 LeftColor { get; init; }
}