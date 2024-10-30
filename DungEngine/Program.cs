namespace DungEngine
{
    class Program
    {
        static void Main(string[] _)
        {
            var game = new Game(new() {
                Title = "Test window",
                Player = new("Karl Smart"),
                // Color = new(ConsoleColor.White, ConsoleColor.Black)
            });
            game.Run();
        }
    }
}