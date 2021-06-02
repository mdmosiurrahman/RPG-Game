using System;

namespace RPG_Game.Attribute
{
    public class PrimaryAttributes
    {
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public static PrimaryAttributes operator +(PrimaryAttributes x, PrimaryAttributes y)
        {
            PrimaryAttributes primaryAttributes = new PrimaryAttributes
            {
                Strength = x.Strength + y.Strength,
                Dexterity = x.Dexterity + y.Dexterity,
                Intelligence = x.Intelligence + y.Intelligence,
                Vitality = x.Vitality + y.Vitality
            };

            return primaryAttributes;
        }
    }
}

