namespace MortalEngines.Factories
{
    using System;

    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class TankFactory
    {
        public static IMachine CreateTank(string name, double attackPoints, double defensePoints)
        {
            IMachine tank;

            try
            {
                tank = new Tank(name, attackPoints, defensePoints);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return tank;
        }

    }
}
