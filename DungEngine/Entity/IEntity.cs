namespace DungEngine.Entity
{
    public interface IEntity
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
    }
}