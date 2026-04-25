using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.Utils;

namespace ZomatoFoodApi_Service
{
    public class EmployeeService : IEmployeeService
    {
        public Task<int> AddEmployes(Employee empdetail)
        {
        }

        public Task<bool> DeleteEmployesById(int empid)
        {
        }

        public Task<EmployeeDto> GetEmployeeById(int empid)
        {
        }

        public Task<List<EmployeeDto>> GetEmployees()
        {
        }

        public Task<bool> UpdateEmploye(Employee empdetail)
        {
            throw new ();
        }
    }
}
