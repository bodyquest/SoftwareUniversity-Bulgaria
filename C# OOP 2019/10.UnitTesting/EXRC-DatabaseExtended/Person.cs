namespace EXRC_DatabaseExtended
{
    public class Person
    {
        public Person(string username, int id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; private set; }

        public int Id { get; private set; }
    }
}
