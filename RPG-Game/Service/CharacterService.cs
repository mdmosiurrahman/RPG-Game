using RPG_Game.Attribute;
using RPG_Game.Character;
using System;


namespace RPG_Game.Service
{
    public class CharacterService
    {
        public static void PublishHeroDetail(Hero hero)
        {
            // Display character statistics to console
            hero.DamageCalculation();
            hero.SecondaryAttributesCalculation();
            PrimaryAttributes totalAttributes = hero.TotalAttributesCalculation();

            Console.WriteLine("Character Statistics: ");
            Console.WriteLine("Name: " + hero.Name);
            Console.WriteLine("Level: " + hero.Level);
            Console.WriteLine("Vitality: " + totalAttributes.Vitality);
            Console.WriteLine("Strength: " + totalAttributes.Strength);
            Console.WriteLine("Dexterity: " + totalAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + totalAttributes.Intelligence);
            Console.WriteLine("Health: " + hero.SecondaryAttributes.Health);
            Console.WriteLine("Armor Rating: " + hero.SecondaryAttributes.ArmorRating);
            Console.WriteLine("Elemental Resistance: " + hero.SecondaryAttributes.ElementalResistance);
            Console.WriteLine("DPS: " + hero.Damage);

         
        }
    }
}
