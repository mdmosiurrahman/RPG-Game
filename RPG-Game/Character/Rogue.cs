using RPG_Game.EnumType;
using System.Collections.Generic;


namespace RPG_Game.Character
{
    public class Rogue : Hero 
    {
        public Rogue(string Name) : base(Name)
        {
            BasePrimaryAttributes.Vitality = 8;
            BasePrimaryAttributes.Strength = 2;
            BasePrimaryAttributes.Dexterity = 6;
            BasePrimaryAttributes.Intelligence = 1;
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.LEATHER, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.DAGGER, WeaponTypes.SWORD };
            SecondaryAttributesCalculation();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 3;
            BasePrimaryAttributes.Strength += 1;
            BasePrimaryAttributes.Dexterity += 4;
            BasePrimaryAttributes.Intelligence += 1;
            SecondaryAttributesCalculation();
        }

        public override void DamageCalculation()
        {
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (PrimaryAttributes.Dexterity / 100));
        }
    }
}
