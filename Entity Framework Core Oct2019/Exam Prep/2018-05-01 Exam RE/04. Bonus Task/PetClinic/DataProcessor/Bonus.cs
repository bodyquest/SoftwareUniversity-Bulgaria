namespace PetClinic.DataProcessor
{
    using System.Linq;
    using System.Text;
    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var sb = new StringBuilder();

            var vet = context.Vets
                .FirstOrDefault(x => x.PhoneNumber == phoneNumber);

            if (vet == null)
            {
                sb.AppendLine($"Vet with phone number {phoneNumber} not found!");
            }
            else
            {
                string oldProfession = vet.Profession;
                vet.Profession = newProfession;
                context.Vets.Update(vet);
                context.SaveChanges();
                sb.AppendLine($"{vet.Name}'s profession updated from {oldProfession} to {newProfession}.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
