using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resmap.Domain;

namespace Resmap.Data
{
    public class RelationTagConfiguration : IEntityTypeConfiguration<RelationTag>
    {
        public void Configure(EntityTypeBuilder<RelationTag> modelBuilder)
        {
            // Note: 
            // to include Tags must be called 
            // like that .Include("ProjectTags.Tag")
            // .Include(t => t.Tag) will not work!  

            //modelBuilder.HasKey(t => new { t.ProjectId, t.TagId });

            modelBuilder                
                .HasOne(pt => pt.Relation)
                .WithMany(p => p.RelationTags)
                .HasForeignKey(pt => pt.RelationId);


        }
    }
}
