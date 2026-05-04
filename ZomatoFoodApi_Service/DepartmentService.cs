using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Repository;

namespace ZomatoFoodApi_Service
{
    public class DepartmentService : IDepartmentService
    {
        public IMapper _mapper;
        public IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository , IMapper mapper) 
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddDepartment(DepartmentDto departmentDto)
        {
            //var res = _departmentRepository.AddDepartment;
            Department dept = new Department();
            _mapper.Map(departmentDto, dept);
            var res= await _departmentRepository.AddDepartment(dept);
            return res;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var res = await _departmentRepository.DeleteDepartment(id);
            return res;
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
           var res= await _departmentRepository.GetAllDepartments();
            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();
           return  _mapper.Map<List<DepartmentDto>>(res);

        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
           var res=await _departmentRepository.GetDepartmentById(id);
            DepartmentDto departmentDto = new DepartmentDto();
            return _mapper.Map<DepartmentDto>(res);
        }

        public Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentDto)
        {
            Department dept = new Department();
            _mapper.Map(departmentDto, dept);
            var res = _departmentRepository.UpdateDepartment(dept);
            return Task.FromResult(departmentDto);
        }
    }
}
