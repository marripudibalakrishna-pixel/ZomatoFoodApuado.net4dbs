using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Models;

namespace ZomatoFoodApi_Entities.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int empid);
        Task<int> AddEmployes(Employee empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(Employee empdetail);
    }
}
