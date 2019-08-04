using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmo(string ammunition, int qty);

    bool TryToEquipSoldier(ISoldier soldier);
}

