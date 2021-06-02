using RPG_Game.Attribute;
using RPG_Game.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Item
{
    public class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }
        public PrimaryAttributes ArmorAttributes { get; set; }
        public Armor() 
        { 

        }
        public Armor(string ItemName, int ItemLevel, ArmorSlots ItemSlot, ArmorTypes ArmorType, PrimaryAttributes ArmorAttributes) : base(ItemName, ItemLevel, ItemSlot)
        {
            this.ArmorType = ArmorType;
            this.ArmorAttributes = ArmorAttributes;
        }
    }
}
