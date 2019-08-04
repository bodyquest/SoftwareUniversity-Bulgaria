using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private WareHouse warehouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.warehouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.warehouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                this.army.RegenerateTeam(data[2]);
            }
            else
            {
                var soldier = soldierFactory.CreateSoldier(data[1], data[2], int.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5]));

                if (warehouse.TryToEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierCannotBeEquiped, data[1], data[2]));
                }
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.warehouse.AddAmmo(name, number);
        }
        else if (data[0].Equals("Mission"))
        {
            var mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));

            this.writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        missionController.FailMissionsOnHold();
        writer.AppendLine(OutputMessages.Results);
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, missionController.FailedMissionCounter));
        writer.AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }
    }
}
