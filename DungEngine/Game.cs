using System.Runtime.InteropServices;
using DungEngine.Misc;
using DungEngine.Managers;

namespace DungEngine
{
    public class Game
    {
        private readonly LevelManager lm;

        private readonly GameOptions _options;
        public Game(GameOptions gameOptions)
        {
            _options = new()
            {
                Player = gameOptions.Player,
                Title = gameOptions.Title,
                Size = gameOptions.Size,
                Buffer = gameOptions.Buffer,
                Color = gameOptions.Color
            };

            Console.Title = _options.Title;
            Console.SetWindowSize(_options.Size.X, _options.Size.Y);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            { Console.SetBufferSize(_options.Buffer.X, _options.Buffer.Y); }
            Console.ForegroundColor = _options.Color.Foreground;
            Console.BackgroundColor = _options.Color.Background;

            Console.Clear();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {

            }

            Environment.Exit(0);
        }
    }
}