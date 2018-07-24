using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resmap.Domain;

namespace Resmap.Data
{
    public class RelationTagConfiguration : IEntityTypeConfiguration<RelationTag>
    {
        public void Configure(EntityTypeBuilder<RelationTag> modelBuilder)
        {
            modelBuilder                
                .HasOne(pt => pt.Relation)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.RelationId);
        }
    }
}
