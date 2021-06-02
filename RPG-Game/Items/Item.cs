using RPG_Game.EnumType;


namespace RPG_Game.Item
{
    public abstract class Item
    {
        public string ItemName { get; set; }
        public int ItemLevel { get; set; }
        public ArmorSlots ItemSlot { get; set; }

        public Item() 
        { 
        }

        public Item(string ItemName, int ItemLevel, ArmorSlots ItemSlot)
        {
            this.ItemName = ItemName;
            this.ItemLevel = ItemLevel;
            this.ItemSlot = ItemSlot;
        }
    }
}
