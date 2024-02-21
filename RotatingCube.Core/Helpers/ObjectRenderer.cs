using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using RotatingCube.Core.Models;

namespace RotatingCube.Core.Helpers;

public static class ObjectRenderer
{
    public static void RenderCube(RenderCubeOptions options)
    {
        // Begin drawing
        GL.Begin(PrimitiveType.Quads);
        
        // Front face
        GL.Color4(options.FrontColor);
        GL.Vertex3(-options.Size, -options.Size,  options.Size);
        GL.Vertex3(options.Size, -options.Size,  options.Size);
        GL.Vertex3(options.Size,  options.Size,  options.Size);
        GL.Vertex3(-options.Size,  options.Size,  options.Size);

        // Back face
        GL.Color4(options.BackColor);
        GL.Vertex3(-options.Size, -options.Size, -options.Size);
        GL.Vertex3(-options.Size,  options.Size, -options.Size);
        GL.Vertex3(options.Size,  options.Size, -options.Size);
        GL.Vertex3(options.Size, -options.Size, -options.Size);

        // Top face
        GL.Color4(options.TopColor);
        GL.Vertex3(-options.Size,  options.Size, -options.Size);
        GL.Vertex3(-options.Size,  options.Size,  options.Size);
        GL.Vertex3(options.Size,  options.Size,  options.Size);
        GL.Vertex3(options.Size,  options.Size, -options.Size);

        // Bottom face
        GL.Color4(options.BottomColor);
        GL.Vertex3(-options.Size, -options.Size, -options.Size);
        GL.Vertex3(options.Size, -options.Size, -options.Size);
        GL.Vertex3(options.Size, -options.Size,  options.Size);
        GL.Vertex3(-options.Size, -options.Size,  options.Size);

        // Right face
        GL.Color4(options.RightColor);
        GL.Vertex3(options.Size, -options.Size, -options.Size);
        GL.Vertex3(options.Size,  options.Size, -options.Size);
        GL.Vertex3(options.Size,  options.Size,  options.Size);
        GL.Vertex3(options.Size, -options.Size,  options.Size);

        // Left face
        GL.Color4(options.LeftColor);
        GL.Vertex3(-options.Size, -options.Size, -options.Size);
        GL.Vertex3(-options.Size, -options.Size,  options.Size);
        GL.Vertex3(-options.Size,  options.Size,  options.Size);
        GL.Vertex3(-options.Size,  options.Size, -options.Size);
        
        // End drawing
        GL.End();
    }
}