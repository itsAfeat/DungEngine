using DungEngine.Misc;

namespace DungEngine.Entity
{
    public class Player(string name, int startHealth = 100, int damage = 1, int defense = 0) : IEntity
    {
        public string Name { get; } = name;
        public int Health { get; set; } = startHealth;
        public int Damage { get; set; } = damage;
        public int Defense { get; set; } = defense;

        public List<Item> Inventory { get; set; } = [
            new("guldmønt", -1, ITEM_TYPE.Valuta, "Mønter lavet af den fineste (falske) guld man kan finde", 0),
            new("smørkniv", 1, ITEM_TYPE.Weapon, "En helt almindelig smørrekniv", 1)
        ];
    }
}