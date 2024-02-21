using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using RotatingCube.Core.Helpers;
using RotatingCube.Core.Models;

namespace RotatingCube.Core;

public class Game : IDisposable
{
    private readonly GameWindow game;
    private readonly GameOptions options;
    private Color4[] colors;
    private DateTime lastColorRefresh = DateTime.Now;
    private Vector2 rotationVelocity = Vector2.Zero;

    public Game(GameOptions options)
    {
        this.options = options;
        var windowSettings = new GameWindowSettings
        {
            UpdateFrequency = Constants.Framerate
        };
        var nativeWindowSettings = new NativeWindowSettings
        {
            ClientSize = new Vector2i(this.options.Width, this.options.Height),
            WindowBorder = WindowBorder.Fixed,
            Title = this.options.Title, 
            Vsync = VSyncMode.Adaptive,
            Profile = ContextProfile.Compatability,
            APIVersion = Constants.ApiVersion
        };
        this.game = new GameWindow(windowSettings, nativeWindowSettings);
        
        game.Load += HandleLoad;
        game.UpdateFrame += HandleUpdateFrame;
        game.RenderFrame += HandleRenderFrame;
        
        RefreshColors();
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
    
    private void HandleKeyboardState(KeyboardState state)
    {
        if (state.IsKeyDown(Keys.Escape))
        {
            Environment.Exit(0);
        }

        if (state.IsKeyDown(Keys.Up))
        {
            this.rotationVelocity.X += Constants.RotationAcceleration;
        }
        if (state.IsKeyDown(Keys.Down))
        {
            this.rotationVelocity.X -= Constants.RotationAcceleration;
        }
        if (state.IsKeyDown(Keys.Left))
        {
            this.rotationVelocity.Y += Constants.RotationAcceleration;
        }
        if (state.IsKeyDown(Keys.Right))
        {
            this.rotationVelocity.Y -= Constants.RotationAcceleration;
        }
    }

    private void RefreshColors()
    {
        this.colors = RandomColorsProvider.GetRandomColors(Constants.CubeSides);
        this.lastColorRefresh = DateTime.Now;
    }
    private bool TryRefreshColors()
    {
        if (DateTime.Now - this.lastColorRefresh < Constants.ColorRefreshInterval)
        {
            return false;
        }

        RefreshColors();

        return true;
    }
    
    private RenderCubeOptions GetRenderCubeOptions() 
    {
        if(this.options.RefreshColors)
        {
            TryRefreshColors();
        }
        
        return this.options.ImplicitCubeOptions ??
            new RenderCubeOptions
            {
                Size = Constants.RelativeCubeSize,
                FrontColor = colors[0],
                BackColor = colors[1],
                TopColor = colors[2],
                BottomColor = colors[3],
                RightColor = colors[4],
                LeftColor = colors[5]
            };
    }
    
    private void HandleRenderFrame(FrameEventArgs _)
    {
        // Clear previous frame
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        ObjectRenderer.RenderCube(this.GetRenderCubeOptions());
        
        // Rotate
        GL.Rotate(this.rotationVelocity.X, Vector3.UnitX);
        GL.Rotate(this.rotationVelocity.Y, Vector3.UnitY);
        
        // Swap front and back buggers to display new frame
        game.SwapBuffers();
    }

    public void Dispose()
    {
        game?.Dispose();
    }
}