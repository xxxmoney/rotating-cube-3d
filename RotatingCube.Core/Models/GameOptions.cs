namespace RotatingCube.Core.Models;

public class GameOptions
{
    public int Width { get; set; } = Constants.DefaultWidth;
    public int Height { get; set; } = Constants.DefaultHeight;
    public string Title { get; init; }
    public bool RefreshColors { get; set; } = false;
    public RenderCubeOptions ImplicitCubeOptions { get; set; } = null;
}