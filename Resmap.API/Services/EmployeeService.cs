using Microsoft.EntityFrameworkCore;
using Resmap.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Services
{
    public class EmployeeService : Repository<Employee>, IEmployeeService
    {        

        public EmployeeService(ApplicationDbContext context) 
            : base(context)
        {          
        }
       
       
    }
}
