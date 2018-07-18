using Microsoft.Extensions.DependencyInjection;
using Resmap.Data;
using Resmap.Data.Services;

namespace Resmap.API
{
    public static class DependencyServices
    {
        public static void Register(IServiceCollection services)
        {
            // Scoped            
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<IEntityTypeProvider, EntityTypeProvider>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITagService, TagService>();            
            services.AddScoped(typeof(IResourceService<>), typeof(ResourceService<>));
            services.AddScoped(typeof(IEventService<>), typeof(EventService<>));            
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
