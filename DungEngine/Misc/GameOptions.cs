using DungEngine.Entity;

namespace DungEngine.Misc
{
    public class GameOptions
    {
        public string Title { get; set; } = null!;
        public Vec2D Size { get; set; } = new(100, 40);
        public Vec2D Buffer { get; set; } = new(100, 40);
        public Player Player { get; set; } = null!;
        public Color Color { get; set; } = new();
    }
}