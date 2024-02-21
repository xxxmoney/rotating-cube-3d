using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using RotatingCube.Core.Models;

namespace RotatingCube.Core;

public class Game : IDisposable
{
    private readonly GameWindow game;

    public Game()
    {
        var windowSettings = new GameWindowSettings
        {
            UpdateFrequency = Constants.Framerate
        };
        var nativeWindowSettings = new NativeWindowSettings
        {
            ClientSize = new Vector2i(Constants.DefaultWidth, Constants.DefaultHeight),
            Title = Constants.Title, 
            Vsync = VSyncMode.Adaptive,
            Profile = ContextProfile.Compatability,
            APIVersion = Constants.ApiVersion
        };
        this.game = new GameWindow(windowSettings, nativeWindowSettings);
        
        game.Load += HandleLoad;
        game.Resize += HandleResize;
        game.UpdateFrame += HandleUpdateFrame;
        game.RenderFrame += HandleRenderFrame;
    }
    
    public void Run()
    {
        game.Run();
    }
    
    private void HandleUpdateFrame(FrameEventArgs e)
    {
        HandleKeyboardState(this.game.KeyboardState);
    }

    private static void HandleLoad()
    {
        // Set the background color
        GL.ClearColor(Color4.CornflowerBlue);
    }

    private static void HandleResize(ResizeEventArgs e)
    {
        // Set the viewport to match the window size
        GL.Viewport(0, 0, Constants.DefaultWidth, Constants.DefaultHeight);
    }
    
    private static void HandleKeyboardState(KeyboardState state)
    {
        if (state.IsKeyDown(Keys.Escape))
        {
            Environment.Exit(0);
        }

        if (state.IsKeyDown(Keys.Up))
        {
            GL.Rotate(Constants.RotationSpeed, Vector3.UnitX);
        }
        if (state.IsKeyDown(Keys.Down))
        {
            GL.Rotate(-Constants.RotationSpeed, Vector3.UnitX);
        }
        if (state.IsKeyDown(Keys.Left))
        {
            GL.Rotate(Constants.RotationSpeed, Vector3.UnitY);
        }
        if (state.IsKeyDown(Keys.Right))
        {
            GL.Rotate(-Constants.RotationSpeed, Vector3.UnitY);
        }
    }

    private void HandleRenderFrame(FrameEventArgs _)
    {
        // Clear previous frame
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        ObjectRenderer.RenderCube(new RenderCubeOptions
        {
            Size = Constants.RelativeCubeSize,
            FrontColor = Color4.Red,
            BackColor = Color4.Green,
            TopColor = Color4.Blue,
            BottomColor = Color4.Yellow,
            RightColor = Color4.Magenta,
            LeftColor = Color4.Cyan
        });
        
        // Swap front and back buggers to display new frame
        game.SwapBuffers();
    }

    public void Dispose()
    {
        game?.Dispose();
    }
}