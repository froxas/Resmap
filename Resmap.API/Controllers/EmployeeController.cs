using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : BaseCrudController<
        Employee, 
        EmployeeDto, 
        EmployeeForCreationDto, 
        EmployeeForUpdateDto>
    {
        public EmployeeController(
           ICrudService<Employee> crudService) : base(crudService)
        {
        }
    } 
}
