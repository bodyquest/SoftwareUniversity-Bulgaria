namespace StorageMaster
{
    using Core;

    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine(new StorageMaster());
            engine.Run();
        }
    }
}