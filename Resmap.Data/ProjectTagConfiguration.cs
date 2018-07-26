using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resmap.Domain;

namespace Resmap.Data
{
    public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
    {
        public void Configure(EntityTypeBuilder<ProjectTag> modelBuilder)
        {
            modelBuilder                             
                .HasOne(pt => pt.Project)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.ProjectId);
        }
    }
}
