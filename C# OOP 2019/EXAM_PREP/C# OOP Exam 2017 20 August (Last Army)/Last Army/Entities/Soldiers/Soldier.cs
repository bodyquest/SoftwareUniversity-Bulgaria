using System;
using System.Linq;
using System.Collections.Generic;

public abstract class Soldier : ISoldier
{
    private const double MAX_ENDURANCE = 100;
    private const int BASE_REGENERATE_INCREASE = 10;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        private set
        {
            this.endurance = Math.Min(value, MAX_ENDURANCE);
        }
    }

    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (Age + Experience) * OverallSkillMultiplier;

    protected abstract List<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected virtual int RegenerateIncrease => BASE_REGENERATE_INCREASE;

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in Weapons.Values.Where( w=> w!= null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);
            if (weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + RegenerateIncrease;
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}