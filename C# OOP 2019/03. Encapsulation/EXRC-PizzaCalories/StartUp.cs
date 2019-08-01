namespace EXRC_PizzaCalories
{
    using EXRC_PizzaCalories.Core;
    using EXRC_PizzaCalories.Models;

    public class StartUp
    {
        private static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
