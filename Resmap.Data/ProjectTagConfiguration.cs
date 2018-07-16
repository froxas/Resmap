using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resmap.Domain;

namespace Resmap.Data
{
    public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
    {
        public void Configure(EntityTypeBuilder<ProjectTag> modelBuilder)
        {
            // Note: 
            // to include Tags must be called 
            // like that .Include("ProjectTags.Tag")
            // .Include(t => t.Tag) will not work!  

            //modelBuilder.HasKey(t => new { t.ProjectId, t.TagId });

            modelBuilder
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTags)
                .HasForeignKey(pt => pt.ProjectId);


        }
    }
}
