using RPG_Game.Character;

using System;
using Xunit;

namespace RPG_Test
{
    public class HeroTest
    {
        // A character is level 1 when character created
        [Fact]
        public void Level_Of_Character_when_Created()
        {
            Warrior w = new Warrior("Mosiur");
            Assert.Equal(1, w.Level);
        }


        // A character gains a level and it should be level up 2
        [Fact]
        public void Character_Gain_Level_Up()
        {
            Warrior w = new Warrior("Mosiur");
            w.LevelUp();
            Assert.Equal(2,w.Level);
        }

        // Gain 0 or less levels,it should be thrown exception
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Gain_Zero_OR_Negative_Number_ShouldThrowArgumentException(int lv)
        {
            Warrior w = new Warrior("Mosiur");

            Assert.Throws<Exception>(() => w.LevelUp(lv));
        }

        //Each character class(total four character) is created with dafault attribute value in level1.
        [Fact]
        public void Testing_Innitial_Value_For_Character_Warrior()
        {
            Warrior w = new Warrior("Mosiur");
            Assert.Equal(10,w.BasePrimaryAttributes.Vitality);
            Assert.Equal(5, w.BasePrimaryAttributes.Strength);
            Assert.Equal(2, w.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, w.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_Innitial_Value_For_Character_Mage()
        {
            Mage m = new Mage("Mosiur");
            Assert.Equal(5, m.BasePrimaryAttributes.Vitality);
            Assert.Equal(1, m.BasePrimaryAttributes.Strength);
            Assert.Equal(1, m.BasePrimaryAttributes.Dexterity);
            Assert.Equal(8, m.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_Innitial_Value_For_Character_Ranger()
        {
            Ranger r = new Ranger("Mosiur");
            Assert.Equal(8, r.BasePrimaryAttributes.Vitality);
            Assert.Equal(1, r.BasePrimaryAttributes.Strength);
            Assert.Equal(7, r.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, r.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_Innitial_Value_For_Character_Rogue()
        {
            Rogue ro = new Rogue("Mosiur");
            Assert.Equal(8, ro.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, ro.BasePrimaryAttributes.Strength);
            Assert.Equal(6, ro.BasePrimaryAttributes.Dexterity);
            Assert.Equal(1, ro.BasePrimaryAttributes.Intelligence);
        }


        //Each character class(total four character) has their attributes increased when leveling up.
        [Fact]
        public void Testing_LevelUp_Value_For_Character_Warrior()
        {
            Warrior w = new Warrior("Mosiur");
            w.LevelUp();
            Assert.Equal(15, w.BasePrimaryAttributes.Vitality);
            Assert.Equal(8, w.BasePrimaryAttributes.Strength);
            Assert.Equal(4, w.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, w.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_LevelUp_Value_For_Character_Mage()
        {
            Mage m = new Mage("Mosiur");
            m.LevelUp();
            Assert.Equal(8, m.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, m.BasePrimaryAttributes.Strength);
            Assert.Equal(2, m.BasePrimaryAttributes.Dexterity);
            Assert.Equal(13, m.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_LevelUp_Value_For_Character_Ranger()
        {
            Ranger r = new Ranger("Mosiur");
            r.LevelUp();
            Assert.Equal(10, r.BasePrimaryAttributes.Vitality);
            Assert.Equal(2, r.BasePrimaryAttributes.Strength);
            Assert.Equal(12, r.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, r.BasePrimaryAttributes.Intelligence);
        }

        [Fact]
        public void Testing_LevelUp_Value_For_Character_Rogue()
        {
            Rogue ro = new Rogue("Mosiur");
            ro.LevelUp();
            Assert.Equal(11, ro.BasePrimaryAttributes.Vitality);
            Assert.Equal(3, ro.BasePrimaryAttributes.Strength);
            Assert.Equal(10, ro.BasePrimaryAttributes.Dexterity);
            Assert.Equal(2, ro.BasePrimaryAttributes.Intelligence);
        }

        //Secondary stats are calculated from levelled up character with create a warrior
        [Fact]
        public void Calculate_Secondary_Attribute_Test_for_Warrior()
        {
            Warrior w = new Warrior("Mosiur");
            w.LevelUp();
            Assert.Equal(150, w.SecondaryAttributes.Health);
            Assert.Equal(12, w.SecondaryAttributes.ArmorRating);
            Assert.Equal(2, w.SecondaryAttributes.ElementalResistance);
        }


    }
}
