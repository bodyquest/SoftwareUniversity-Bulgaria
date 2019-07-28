namespace StorageMaster
{
    using StorageMaster_BusinessLogic.Core;

    public class StartUp
    {
        public static void Main()
        {
            StorageMaster = new StorageMaster();
            Engine engine = new Engine();
            engine.Run();
        }
    }
}