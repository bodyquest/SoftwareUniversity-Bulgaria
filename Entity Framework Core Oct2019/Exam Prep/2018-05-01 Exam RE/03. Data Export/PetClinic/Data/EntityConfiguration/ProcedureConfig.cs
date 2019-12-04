using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class ProcedureConfig //: IEntityTypeConfiguration<Procedure>
    {
        //public void Configure(EntityTypeBuilder<Procedure> builder)
        //{
        //    builder.HasOne(p => p.Animal)
        //        .WithMany(a => a.Procedures)
        //        .HasForeignKey(p => p.AnimalId);

        //    builder.HasOne(p => p.Vet)
        //        .WithMany(v => v.Procedures)
        //        .HasForeignKey(p => p.VetId);
        //}
    }
}
