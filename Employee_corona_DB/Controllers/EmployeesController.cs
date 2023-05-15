using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_corona_DB.Models;
using Employee_corona_DB.Services;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using MongoDB.Driver;

namespace Employee_corona_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
       
        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _employeeService.Get();


        [HttpGet("{id:length(9)}", Name = "GetEmp")]
        public ActionResult<Employee> Get(string id)
        {
            var emp = _employeeService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }


        [HttpPost]
        public async Task<IActionResult> Post(Employee e)
        {
           
            await _employeeService.CreateAsync(e);

            
            
            if (DateTime.Compare((e.PositiveResultDate), (e.RecoveryDate)) > 0)
            {
                return NotFound();

            }
            return CreatedAtAction(nameof(Get), new { id = e.IdentityCard }, e);
        }

        

        

        

    }
}

