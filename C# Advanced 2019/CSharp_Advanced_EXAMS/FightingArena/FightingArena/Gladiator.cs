namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int sum = this.Stat.Strength + this.Stat.Flexibility + this.Stat.Agility + this.Stat.Skills + this.Stat.Intelligence + this.Weapon.Size + this.Weapon.Solidity + this.Weapon.Sharpness;
            return sum;
        }

        public int GetWeaponPower()
        {
            int sum = this.Weapon.Size + this.Weapon.Solidity + this.Weapon.Sharpness;
            return sum;
        }

        public int GetStatPower()
        {
            int sum = this.Stat.Strength + this.Stat.Flexibility + this.Stat.Agility + this.Stat.Skills + this.Stat.Intelligence;
            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Name} - {GetTotalPower()}");
            result.AppendLine($"  Weapon Power: {GetWeaponPower()}");
            result.AppendLine($"  Stat Power: {GetStatPower()}");
            return result.ToString();
        }
    }
}
