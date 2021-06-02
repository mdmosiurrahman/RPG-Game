using RPG_Game.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Character
{
    public  class Warrior : Hero
    {
        public Warrior(string Name) : base(Name)
        {
            BasePrimaryAttributes.Vitality = 10;
            BasePrimaryAttributes.Strength = 5;
            BasePrimaryAttributes.Dexterity = 2;
            BasePrimaryAttributes.Intelligence = 1;
            AllowedArmor = new List<ArmorTypes> { ArmorTypes.PLATE, ArmorTypes.MAIL };
            AllowedWeapons = new List<WeaponTypes> { WeaponTypes.AXE, WeaponTypes.HAMMER, WeaponTypes.SWORD };
            SecondaryAttributesCalculation();
        }

        public override void LevelUp(int lvl = 1)
        {
            base.LevelUp(lvl);
            BasePrimaryAttributes.Vitality += 5;
            BasePrimaryAttributes.Strength += 3;
            BasePrimaryAttributes.Dexterity += 2;
            BasePrimaryAttributes.Intelligence += 1;
            SecondaryAttributesCalculation();
        }

        public override void DamageCalculation()
        {
            var totalAttributes = TotalAttributesCalculation();
            double WeaponDps = CalcWeaponDPS();
            Damage = WeaponDps * (1 + (totalAttributes.Strength / 100));
        }
    }
}
