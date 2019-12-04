namespace PetClinic.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using PetClinic.Models;

    public class AnimalConfig //: IEntityTypeConfiguration<Animal>
    {
        //public void Configure(EntityTypeBuilder<Animal> builder)
        //{
        //    //builder.HasOne(a => a.Passport)
        //    //    .WithOne(p => p.Animal)
        //    //    .HasForeignKey<Animal>(a => a.PassportSerialNumber);
        //}
    }
}
