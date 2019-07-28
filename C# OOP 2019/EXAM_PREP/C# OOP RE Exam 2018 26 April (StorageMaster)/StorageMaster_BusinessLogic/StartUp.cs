namespace StorageMaster
{
    using StorageMaster_BusinessLogic.Core;

    public class StartUp
    {
        public static void Main()
        {
            StorageMaster storageMaster = new StorageMaster();
            Engine engine = new Engine(storageMaster);
            engine.Run();
        }
    }
}