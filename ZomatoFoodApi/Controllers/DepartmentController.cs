using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Service;

namespace ZomatoFoodApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentDto departmentDto)
        {//dtos are used to transafer the data purpose used.

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata = await _departmentService.AddDepartment(departmentDto);
                    return StatusCode(StatusCodes.Status201Created, deptdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteDepartmentById/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (id < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _departmentService.DeleteDepartment(id);
                if (deptdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var empdata = await _departmentService.GetAllDepartments();
                if (empdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetDepartmentById/{deptid}")]
        public async Task<IActionResult> Get(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _departmentService.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] DepartmentDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata = await _departmentService.UpdateDepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
