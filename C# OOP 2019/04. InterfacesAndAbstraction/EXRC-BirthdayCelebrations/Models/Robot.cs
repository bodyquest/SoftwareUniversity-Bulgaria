namespace EXRC_BorderControl.Models
{
    using EXRC_BirthdayCelebrations.Interfaces;

    public class Robot : IIdentifiable
    {
        public Robot(string mode, string id)
        {
            this.Model = Model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get ; private set; }
    }
}
