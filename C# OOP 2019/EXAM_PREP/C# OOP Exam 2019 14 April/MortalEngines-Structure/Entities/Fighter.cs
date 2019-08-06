using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HP = 200;
        private const double TOGGLE_ATTACK_POINTS = 50;
        private const double TOGGLE_DEFENCE_POINTS = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + TOGGLE_ATTACK_POINTS, defensePoints - TOGGLE_DEFENCE_POINTS, INITIAL_HP)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= TOGGLE_ATTACK_POINTS;
                this.DefensePoints += TOGGLE_DEFENCE_POINTS;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += TOGGLE_ATTACK_POINTS;
                this.DefensePoints -= TOGGLE_DEFENCE_POINTS;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {(this.AggressiveMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
