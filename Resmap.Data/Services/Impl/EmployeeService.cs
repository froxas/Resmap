using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class EmployeeService : Repository<Employee>, IEmployeeService
    {      
        public EmployeeService(ApplicationDbContext context) 
            : base(context)
        {          
        }
              
    }
}
