using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class ProcedureAnimalAidConfig //: IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        //public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        //{
        //    builder.HasKey(x => new { x.AnimalAidId, x.ProcedureId });

        //    builder.HasOne(x => x.Procedure)
        //        .WithMany(p => p.ProcedureAnimalAids)
        //        .HasForeignKey(x => x.ProcedureId);

        //    builder.HasOne(x => x.AnimalAid)
        //        .WithMany(a => a.AnimalAidProcedures)
        //        .HasForeignKey(x => x.AnimalAidId);
        //}
    }
}
