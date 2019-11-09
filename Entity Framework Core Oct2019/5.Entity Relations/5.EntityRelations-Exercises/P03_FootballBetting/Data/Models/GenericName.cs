namespace P03_FootballBetting.Data.Models
{
    public class GenericName
    {
        public GenericName()
        {
        }

        public GenericName(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
