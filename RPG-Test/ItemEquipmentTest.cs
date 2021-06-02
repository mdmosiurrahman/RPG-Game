using RPG_Game.Attribute;
using RPG_Game.Character;
using RPG_Game.EnumType;
using RPG_Game.ExceptionHandling;
using RPG_Game.Item;
using Xunit;

namespace RPG_Test
{
    public class ItemEquipmentTest
    {
        // Use Warrior class for testing an AXE for an example of weapon
        [Fact]
        public void Equip_Weapon_Test_With_Exception()
        {
            Warrior w = new Warrior("Mosiur");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Assert.Throws<InvalidWeaponException>(() => w.EquipWeapon(testAxe));
        }

        // Use PLATE body armor for testing
        [Fact]
        public void Equip_Armor_Test_With_Exception()
        {
            Warrior w = new Warrior("Mosiur");
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.BODY,
                ArmorType = ArmorTypes.PLATE,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
           
            Assert.Throws<InvalidArmorException>(() => w.EquipArmor(testPlateBody));
        }

        // Use weapon Type as BOW for testing
        [Fact]
        public void Equip_Roung_Weapon_Bow_Test_With_Exception()
        {
            Warrior w = new Warrior("Mosiur");
            Weapon testBow = new Weapon()
            {
                ItemName = "Common bow",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.WEAPON,
                WeaponType = WeaponTypes.BOW,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Assert.Throws<InvalidWeaponException>(() => w.EquipWeapon(testBow));
        }

        // Use Cloth head armor for testing
        [Fact]
        public void Equip_Armor_Cloth_Test_With_Exception()
        {
            Warrior w = new Warrior("Mosiur");
            Armor testClothHead = new Armor()
            {
                ItemName = "Common cloth head armor",
                ItemLevel = 2,
                ItemSlot = ArmorSlots.HEAD,
                ArmorType = ArmorTypes.CLOTH,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
            };
            Assert.Throws<InvalidArmorException>(() => w.EquipArmor(testClothHead));
        }

    }
}
