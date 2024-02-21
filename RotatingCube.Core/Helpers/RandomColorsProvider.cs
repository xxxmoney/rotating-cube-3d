using OpenTK.Mathematics;

namespace RotatingCube.Core.Helpers;

public static class RandomColorsProvider
{
    public static Color4[] GetRandomColors(int count)
    {
        var colors = new Color4[count];
        var random = new Random();
        for (var i = 0; i < count; i++)
        {
            colors[i] = new Color4((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1.0f);
        }
        return colors;
    }
}