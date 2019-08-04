using System.Linq;
using System.Collections.Generic;

public class Army : IArmy
{
    private List<ISoldier> soldiers;

    public Army()
    {
        soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers;

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in soldiers.Where(s => s.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
}

