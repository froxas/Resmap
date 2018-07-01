using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface IEmployeeService : IRepository<Employee>
    {
        /// <summary>
        /// Returns employee by id with all properties included
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetByIdAllIncluded(Guid id);

        /// <summary>
        /// Returns all employees with all properties included
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployeesAllIncluded();
    }    
}
