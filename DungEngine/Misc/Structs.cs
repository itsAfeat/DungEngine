namespace DungEngine.Misc
{
    public struct Vec2D(int x, int y)
    {
        public int X = x;
        public int Y = y;

        public Vec2D((int x, int y) tuple) : this(tuple.x, tuple.y)
        { }
    }

    public struct Color(ConsoleColor fore, ConsoleColor back)
    {
        public ConsoleColor Foreground = fore;
        public ConsoleColor Background = back;

        public Color((ConsoleColor fore, ConsoleColor back) colors) : this(colors.fore, colors.back)
        { }

        public Color() : this(ConsoleColor.White, ConsoleColor.Black)
        {}

    }
}