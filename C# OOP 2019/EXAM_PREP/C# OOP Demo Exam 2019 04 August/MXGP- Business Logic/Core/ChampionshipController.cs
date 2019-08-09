namespace MXGP.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using MXGP.Models.Races;
    using MXGP.Repositories;
    using MXGP.Models.Riders;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Models.Motorcycles.Contracts;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riderRepo;
        private readonly IRepository<IMotorcycle> motorRepo;
        private readonly IRepository<IRace> raceRepo;

        public ChampionshipController()
        {
            this.riderRepo = new RiderRepository();
            this.motorRepo = new MotorcycleRepository();
            this.raceRepo = new RaceRepository();
        }

        public string CreateRider(string riderName) 
        {
            var rider = this.riderRepo.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);

            this.riderRepo.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motor = this.motorRepo.GetByName(model);

            if (motor != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Power")
            {
                motor = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motor = new SpeedMotorcycle(model, horsePower);
            }

            this.motorRepo.Add(motor);

            return $"{motor.GetType().Name} {model} is created.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepo.GetByName(riderName);
            var motor = this.motorRepo.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motor == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motor);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepo.GetByName(raceName);
            var rider = this.riderRepo.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepo.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            this.raceRepo.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        { 
            var race = this.raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var winners = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Rider {winners[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {winners[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {winners[2].Name} is third in {raceName} race.");

            this.raceRepo.Remove(race);

            return sb.ToString().TrimEnd();
        } 
    }
}
