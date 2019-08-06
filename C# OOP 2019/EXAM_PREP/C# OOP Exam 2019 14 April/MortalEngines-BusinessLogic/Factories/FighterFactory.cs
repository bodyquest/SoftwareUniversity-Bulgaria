using System;
using System.Text;
using System.Collections.Generic;

using MortalEngines.Entities.Contracts;
using MortalEngines.Factories.Contracts;
using MortalEngines.Entities;

namespace MortalEngines.Factories
{
    public class FighterFactory
    {
        public static IMachine CreateFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine fighter;

            try
            {
                fighter = new Fighter(name, attackPoints, defensePoints);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return fighter;
        }
    }
}
