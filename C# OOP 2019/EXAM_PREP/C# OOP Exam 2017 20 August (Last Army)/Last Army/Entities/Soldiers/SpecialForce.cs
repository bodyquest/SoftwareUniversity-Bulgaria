﻿
using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const int REGENERATE_INCREASE = 30;

    private const double overallSkillMiltiplier = 3.5;
    protected override double OverallSkillMultiplier => overallSkillMiltiplier;

    private readonly List<string> weaponsAllowed = new List<string>
    {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
    };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    protected override int RegenerateIncrease => REGENERATE_INCREASE;
}
