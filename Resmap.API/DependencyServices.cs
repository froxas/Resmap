using Microsoft.Extensions.DependencyInjection;
using Resmap.Data.Services;

namespace Resmap.API
{
    public static class DependencyServices
    {
        public static void Register(IServiceCollection services)
        {
            // Scoped
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRelationService, RelationService>();
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<IEntityTypeProvider, EntityTypeProvider>();
            services.AddScoped(typeof(IEventService<>), typeof(EventService<>));
            services.AddScoped(typeof(IResourceService<>), typeof(ResourceService<>));
            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));
        }
    }
}
