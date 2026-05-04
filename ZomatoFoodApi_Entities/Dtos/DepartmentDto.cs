using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodApi_Entities.Dtos
{
    public   class DepartmentDto
    {
            
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
    }
}
