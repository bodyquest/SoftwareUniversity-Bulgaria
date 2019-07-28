namespace StorageMaster_BusinessLogic.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private StorageMaster storageMaster; 
        private bool isRunning;

        public Engine()
        {
            storageMaster = new StorageMaster();
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string line = Console.ReadLine();

                string[] tokens = line.Split();

                string command = tokens[0];
                string output = "";

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            {
                                string type = tokens[1];
                                double price = double.Parse(tokens[2]);
                                output = this.storageMaster.AddProduct(type, price);
                                break;
                            }

                        case "RegisterStorage":
                            {
                                string type = tokens[1];
                                string name = tokens[2];
                                output = this.storageMaster.RegisterStorage(type, name);
                                break;
                            }

                        case "SelectVehicle":
                            {
                                string name = tokens[1];
                                int slot = int.Parse(tokens[2]);
                                output = this.storageMaster.SelectVehicle(name, slot);
                                break;
                            }

                        case "LoadVehicle":
                            output = this.storageMaster.LoadVehicle(tokens.Skip(1));
                            break;
                        case "SendVehicleTo":
                            {
                                string name = tokens[1];
                                int slot = int.Parse(tokens[2]);
                                string destinationName = tokens[3];

                                output = this.storageMaster.SendVehicleTo(name, slot, destinationName);
                                break;
                            }

                        case "UnloadVehicle":
                            {
                                string name = tokens[1];
                                int slot = int.Parse(tokens[2]);
                                output = this.storageMaster.UnloadVehicle(name, slot);
                                break;
                            }

                        case "GetStorageStatus":
                            {
                                string name = tokens[1];

                                output = this.storageMaster.GetStorageStatus(name);
                                break;
                            }

                        case "END":
                            output = this.storageMaster.GetSummary();
                            this.isRunning = false;
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    output = $"Error: {ioe.Message}";
                }

                Console.WriteLine(output);
            }
        }
    }
}
