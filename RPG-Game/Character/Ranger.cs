using RPG_Game.Attribute;
using RPG_Game.EnumType;
using System.Collections.Generic;


namespace RPG_Game.Character
{
   public class Ranger : Hero
    {
        public Ranger(string Name) : base(Name)
        {
            BasePrimaryAttributes.Vitality = 8;
            BasePrimaryAttributes.Strength = 1;
            BasePrimaryAttributes.Dexterity = 7;
            BasePrimaryAttributes.Intelligence = 1;
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.LEATHER, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.BOW };
            SecondaryAttributesCalculation();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 2;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 5;
            BasePrimaryAttributes.Intelligence += 1;
            SecondaryAttributesCalculation();
        }

        public override void DamageCalculation()
        {
            PrimaryAttributes totalAttributes = TotalAttributesCalculation();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Dexterity / 100));
        }
    }
}
