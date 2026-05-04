using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;

namespace ZomatoFoodApi_Entities.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<bool> AddDepartment(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentDto);
        Task<bool> DeleteDepartment(int id);
    }
}
