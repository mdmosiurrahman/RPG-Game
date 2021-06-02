

using RPG_Game.Attribute;
using RPG_Game.Character;
using RPG_Game.EnumType;
using RPG_Game.ExceptionHandling;
using RPG_Game.Item;
using RPG_Game.Service;
using System;

namespace RPG_Game
{
    class Program
    {
      
        static void Main(string[] args)
        {

            Warrior w = new Warrior("Mosiur");
            Armor testClothHead = new Armor()
            {
                ItemName = "Common cloth head armor",
                ItemLevel = 1,
                ItemSlot = ArmorSlots.HEAD,
                ArmorType = ArmorTypes.PLATE,
                ArmorAttributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
            };
            try
            {
                string equipResponse = w.EquipArmor(testClothHead);
                Console.WriteLine(equipResponse);
            }
            catch (InvalidArmorException ex)
            {
                Console.WriteLine(ex.Message);
            }

            CharacterService.PublishHeroDetail(w);

            Console.ReadKey();

        }
    }
}
