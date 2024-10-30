namespace DungEngine.Misc
{
    public enum ITEM_TYPE
    {
        Healing = 0000001,
        Armor = 0000010,
        Weapon = 0000100,
        Key = 0001000,
        QuestItem = 0010000,
        Lore = 0100000,
        Valuta = 1000000,
        Misc = 0000000
    }

    public class Item(string name, int attribute, ITEM_TYPE type, string? description = null, int amount = 1)
    {
        public int Id { get; }
        public string Name { get; set; } = name.ToLower();
        public string? Description { get; set; } = description;
        public int Amount { get; set; } = amount;
        public int Attribute { get; set; } = attribute;
        public ITEM_TYPE Type { get; set; } = type;
    }
}