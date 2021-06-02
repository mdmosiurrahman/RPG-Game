using RPG_Game.Attribute;
using RPG_Game.EnumType;
using RPG_Game.ExceptionHandling;
using RPG_Game.Item;
using System;
using System.Collections.Generic;


namespace RPG_Game.Character
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public double Damage { get; set; }
        public PrimaryAttributes PrimaryAttributes { get; set; }
        public PrimaryAttributes BasePrimaryAttributes { get; set; } 
        public SecondaryAttributes SecondaryAttributes { get; set; }
        public List<WeaponTypes> AllowedWeapons { get; set; }
        public List<ArmorTypes> AllowedArmor { get; set; }

        public Dictionary<ArmorSlots, RPG_Game.Item.Item> Equipment { get; set; }
        public Hero(string name)
        {
            Name = name;
            Level = 1;

            PrimaryAttributes = new PrimaryAttributes();
            BasePrimaryAttributes = new PrimaryAttributes();
            SecondaryAttributes = new SecondaryAttributes();

        Equipment = new Dictionary<ArmorSlots, RPG_Game.Item.Item>

          {
            {ArmorSlots.HEAD, null},
            {ArmorSlots.BODY, null},
            {ArmorSlots.LEGS, null},
            {ArmorSlots.WEAPON, null}
          };
        }

        
        //When levels up the character,default level is set to 1. we can not passed negative number,it will throw exception
        
        public virtual void LevelUp(int level)
        {
            if (level <= 0)
            {
                throw new Exception();
            }
            Level += level;
        }

        // This method calculate total damege based on weapon and primary attribute
        public abstract void DamageCalculation();

        //The method check if the allowedweapons list contains the type of the weapon and if hero level is greater or equal to the itemlevel of weapon
        public string EquipWeapon(Weapon Weapon)
        {
            if (Weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException("You are not eligible to wear this weapon");
            }

            if (!AllowedWeapons.Contains(Weapon.WeaponType))
            {
                throw new InvalidWeaponException("You are not able to use this weapon");
            }

            Equipment[Weapon.ItemSlot] = Weapon;

            return "New weapon equipped!";
        }


        //The method checks if the AllowedArmor List contains the Type of the armor
        // and if the characters level is above or equal to the itemlevel of the armor.

        public string EquipArmor(Armor Armor)
        {
            if (Armor.ItemLevel > Level)
            {
                throw new InvalidArmorException("You are not eligible to wear this armor");
            }

            if (!AllowedArmor.Contains(Armor.ArmorType))
            {
                throw new InvalidArmorException("You are not eligible to use this Armor");
            }

            Equipment[Armor.ItemSlot] = Armor;

            return "New Armor";
        }


        /// <summary>
        /// Calculates the primary attributes based on the equipped armor.
        /// If an item is equipped in a slot, proceed to add the armor attributes to the calculatedStats object.
        /// </summary>
        /// <returns></returns>
        private PrimaryAttributes CalcPrimaryAttributes()
        {
            PrimaryAttributes calculatedStats = new PrimaryAttributes();
            var armors = new List<Armor>();
            foreach (var equi in Equipment)
            {
                if (equi.Key == ArmorSlots.WEAPON)
                    continue;

                armors.Add((Armor)equi.Value);
            }

            
            foreach (Armor armor in armors)
            {
                if (armor != null)
                {
                    calculatedStats += armor.ArmorAttributes;
                }
            }

            return calculatedStats;
        }

        //totalAttributes calculation based on the primaryattributes and the baseprimaryattributes
        public PrimaryAttributes TotalAttributesCalculation()
        {
            PrimaryAttributes primaryAttributes = CalcPrimaryAttributes();
            PrimaryAttributes totalAttributes = BasePrimaryAttributes + primaryAttributes;

            return totalAttributes;
        }


        /// <summary>
        /// This method calculates the secondary attributes of the hero and the health is calculated by multiplying the hereos total vitality with 10
        /// </summary>
        public void SecondaryAttributesCalculation()
        {
            PrimaryAttributes totalAttributes = TotalAttributesCalculation();

            SecondaryAttributes.Health = totalAttributes.Vitality * 10;
            SecondaryAttributes.ArmorRating = totalAttributes.Strength + totalAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = totalAttributes.Intelligence;
        }


        /// <summary>
        /// Here weaponSpeed and weaponDamage is multiplied and returned WeaponsDPS
        /// </summary>
        /// <returns></returns>
        
         public double CalcWeaponDPS()
        {
            double weaponDPS = 1;
            
            if (Equipment.ContainsKey(ArmorSlots.WEAPON)) {

                Weapon weapon=Equipment[ArmorSlots.WEAPON] as Weapon;

            if (weapon != null)
            {
                double weaponSpeed = weapon.WeaponAttributes.AttackSpeed;
                int weaponDamage = weapon.WeaponAttributes.Damage;
                weaponDPS = weaponDamage * weaponSpeed;
            }

            }
            return weaponDPS;
        }

     }
}
