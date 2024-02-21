
using RotatingCube.Core;
using RotatingCube.Core.Models;

var options = new GameOptions
{
    Title = "Rotating Cube",
    RefreshColors = true
};
using var game = new Game(options);
game.Run();

