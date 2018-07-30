using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class ProjectService : Repository<Project>, IProjectService
    {
        public ProjectService(ApplicationDbContext context)
           : base(context)
        {
        }              
    }
}
