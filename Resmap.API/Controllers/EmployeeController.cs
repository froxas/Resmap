using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Data;
using Resmap.API.Models;
using Resmap.API.Services;
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

        [HttpGet(Name = "GetEmployees")]
        public IActionResult GetEmployees()
        {
            var employeesFromRepo = _employeeService.GetAllIncludes(r => r.Address, n => n.Note);
            var employees = Mapper.Map<IEnumerable<EmployeeDto>>(employeesFromRepo);
            return Ok(employees);                      
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult GetEmployee(Guid id)
        {
            var employeeFromRepo = _employeeService.GetById(e => e.Id == id, c => c.Address, n => n.Note);

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
    }
}
