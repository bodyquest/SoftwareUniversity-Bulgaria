using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionsQty;
    private IAmmunitionFactory ammoFactory;

    public WareHouse()
    {
        ammunitionsQty = new Dictionary<string, int>();
        ammoFactory = new AmmunitionFactory();
    }

    public void AddAmmo(string ammunition, int qty)
    {
        if (ammunitionsQty.ContainsKey(ammunition))
        {
            ammunitionsQty[ammunition] += qty;
        }
        else
        {
            ammunitionsQty.Add(ammunition, qty);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryToEquipSoldier(soldier);

        }
    }

    public bool TryToEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier
            .Weapons
            .Where(w => w.Value == null)
            .Select(w => w.Key)
            .ToList();

        bool isSoldierEquiped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if (ammunitionsQty.ContainsKey(weapon) && ammunitionsQty[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammoFactory.CreateAmmunition(weapon);
                ammunitionsQty[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }
}

