using RPG_Game.EnumType;
using System.Collections.Generic;


namespace RPG_Game.Character
{
    public class Mage : Hero
    {
        public Mage(string Name) : base(Name)
        {
            
            BasePrimaryAttributes.Vitality = 5;
            BasePrimaryAttributes.Strength = 1;
            BasePrimaryAttributes.Dexterity = 1;
            BasePrimaryAttributes.Intelligence = 8;
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.CLOTH };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.STAFF, WeaponTypes.WAND };
            SecondaryAttributesCalculation();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 3;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 1;
            BasePrimaryAttributes.Intelligence += 5;
            SecondaryAttributesCalculation();
        }

        public override void DamageCalculation()
        {
            var totalAttributes = TotalAttributesCalculation();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Intelligence / 100));
        }
    }
}

