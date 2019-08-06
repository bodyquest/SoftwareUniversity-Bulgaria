using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HP = 100;
        private const double TOGGLE_ATTACK_POINTS = 50;
        private const double TOGGLE_DEFENCE_POINTS = 25;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - TOGGLE_ATTACK_POINTS, defensePoints + TOGGLE_DEFENCE_POINTS, INITIAL_HP)
        {
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;

                this.AttackPoints += TOGGLE_ATTACK_POINTS;
                this.DefensePoints -= TOGGLE_DEFENCE_POINTS;
            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= TOGGLE_ATTACK_POINTS;
                this.DefensePoints += TOGGLE_DEFENCE_POINTS;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defence: {(this.DefenseMode? "ON" : "OFF")}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
