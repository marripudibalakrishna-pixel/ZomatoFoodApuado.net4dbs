using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Models;

namespace ZomatoFoodApi_Entities.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<bool> AddDepartment(Department department);
        Task<bool> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
