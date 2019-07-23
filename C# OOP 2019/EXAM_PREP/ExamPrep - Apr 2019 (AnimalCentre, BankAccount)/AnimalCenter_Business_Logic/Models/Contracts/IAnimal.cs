using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; } //private set?

        int Happiness { get; set; }
        //– int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid happiness")

        int Energy { get; set; }
        //– int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid energy")

        int ProcedureTime { get; set; }

        string Owner { get; set; }
        //(by default: "Centre")

        bool IsAdopt { get; set; }
        //(by default: false)

        bool IsChipped { get; set; } 
        //(by default: false)

        bool IsVaccinated { get; set; } 
        //(by default: false)

    }
}
