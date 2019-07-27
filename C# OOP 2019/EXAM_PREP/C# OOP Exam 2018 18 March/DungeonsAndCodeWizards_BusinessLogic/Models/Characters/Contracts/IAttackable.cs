using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
