using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
                
        public EmployeeController(IEmployeeService employeeService) 
            => _employeeService = employeeService;        

        [HttpGet(Name = nameof(GetEmployees))]
        public IActionResult GetEmployees()
        {
            var employeesFromRepo = _employeeService.GetEmployeesAllIncluded();
            var employees = Mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo);
            
            return Ok(employees);                      
        }

        [HttpGet("{id}", Name = nameof(GetEmployee))]
        public IActionResult GetEmployee(Guid id)
        {
            var employeeFromRepo = _employeeService.GetByIdAllIncluded(id);                

            if (employeeFromRepo  ==  null)            
                return NotFound();            
            else
            {
                var employee = Mapper.Map<EmployeeDto>(employeeFromRepo);
                return Ok(employee);
            }            
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            if (employee == null)
                return BadRequest();

            var employeeEntity = Mapper.Map<EmployeeForCreationDto, Employee>(employee);

            _employeeService.Add(employeeEntity);

            if (!_employeeService.Save())
                throw new Exception("Creating employee failed on save.");

            var employeeToReturn = Mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("GetEmployee",
                new { id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employeeFromRepo = _employeeService.GetByIdAllIncluded(id);

            if (employeeFromRepo == null)            
                return NotFound();            

            _employeeService.Delete(employeeFromRepo);
            if (!_employeeService.Save())
                throw new Exception($"Deleting employee {id} failed on save");

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee == null)
                return BadRequest();

            var employeeFromRepo = _employeeService.GetByIdAllIncluded(id);

            if (employeeFromRepo == null)
                return NotFound();

            Mapper.Map(employee, employeeFromRepo);

            if (!_employeeService.Save())
                throw new Exception($"Upating employee {id} failed on save");

            return NoContent();
        }
    }
}
