using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public class EmployeeService : Repository<Employee>, IEmployeeService
    {   
        public EmployeeService(ApplicationDbContext context) 
            : base(context)
        {          
        }        
        public Employee GetByIdAllIncluded(Guid id) 
            => GetById(e => e.Id == id, c => c.Contact, a => a.Address, n => n.Note);

        public IEnumerable<Employee> GetEmployeesAllIncluded()
            => GetAllIncludes(c => c.Contact, r => r.Address, n => n.Note);
    }
}
