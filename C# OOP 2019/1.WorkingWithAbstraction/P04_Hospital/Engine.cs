namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();

                var department = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];

                var fullName = firstName + lastName;

                AddDoctor(fullName);
                AddDepartment(department);

                bool isFree = departments[department].SelectMany(x => x).Count() < 60;

                if (isFree)
                {
                    doctors[fullName].Add(patient);
                    AddPatientToRoom(department, patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];
                    PrintPatientsInDepartment(departmentName);
                }
                else if (args.Length == 2)
                {
                    bool isRoom =  int.TryParse(args[1], out int room);

                    if (isRoom)
                    {
                        string departmentName = args[0];
                        PrintAllPatientsInRooom(room, departmentName);
                    }
                    else
                    {
                        var fullName = args[0] + args[1];
                        PrintPatientsDoctor(fullName);
                    }
                }
                
                command = Console.ReadLine();
            }
        }

        private void PrintPatientsDoctor(string fullName)
        {
            var allPatientsOfDoctor = doctors[fullName]
                                        .OrderBy(x => x)
                                        .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
        }

        private void PrintAllPatientsInRooom(int room, string departmentName)
        {
            var allPatientsInRoom = departments[departmentName][room - 1]
                                        .OrderBy(x => x)
                                        .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInRoom));
        }

        private void PrintPatientsInDepartment(string departmentName)
        {
            var allPatientsInDepartment = departments[departmentName]
                                    .Where(x => x.Count > 0)
                                    .SelectMany(x => x)
                                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string department, string patient)
        {
            int room = 0;

            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            //int targetRoom = departments[department]
            //    .SelectMany(x => x).Where(x => x.Count() < 3)
            //    .FirstOrDefault();
            departments[department][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
