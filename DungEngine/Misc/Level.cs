using DungEngine.Entity;

namespace DungEngine.Misc
{
    public class Level(Vec2D playerStart, char[,] map,
                       Dictionary<Vec2D, Item> items,
                       Dictionary<Vec2D, IEntity> entities)
    {
        public readonly Vec2D PlayerStart = playerStart;
        public readonly char[,] Map = map;
        public readonly Dictionary<Vec2D, Item> Items = items;
        public readonly Dictionary<Vec2D, IEntity> Entities = entities;
    }
}