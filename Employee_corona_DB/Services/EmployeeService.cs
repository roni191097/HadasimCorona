using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Employee_corona_DB.Models;
using MongoDB.Bson;

namespace Employee_corona_DB.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);
            if (_employees == null)
            {
                database.CreateCollection(settings.EmployeesCollectionName);
            }

        }

        public List<Employee> Get()
        {
            List<Employee> employees;
            employees = _employees.Find(emp => true).ToList();
            return employees;
        }
        public Employee Get(string id) =>
               _employees.Find<Employee>(emp => emp.IdentityCard == id).FirstOrDefault();


        public async Task CreateAsync(Employee e) =>
        await _employees.InsertOneAsync(e);
    }

    }


