using RPG_Game.Attribute;
using RPG_Game.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Item
{
    public class Weapon:Item
    {
        public WeaponTypes WeaponType { get; set; }
        public WeaponAttributes WeaponAttributes { get; set; }
        public Weapon()
        { 

        }
        public Weapon(string ItemName, int ItemLevel, ArmorSlots ItemSlot, WeaponTypes WeaponType, WeaponAttributes WeaponAttributes) : base(ItemName, ItemLevel, ItemSlot)
        {
            this.WeaponType = WeaponType;
            this.WeaponAttributes = WeaponAttributes;
        }
    }
}
