using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_DbContectivity;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.Utils;

namespace ZomatoFoodApi_Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public IConnectionFactory _connectionFactory;
        public DepartmentRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public async Task<bool> AddDepartment(Department department)
        {
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                //pass the data to input partameters of your storedprocedure
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, department.DeptName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, department.DeptLocation);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
                //var departmentCount = (int)cmd.Parameters[StoredprocedureParameters.Insertedvariable].Value;
                return true;
            }
            // return true;

        }

        public async Task<bool> DeleteDepartment(int id)
        {
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                List<Department> lstDept = new List<Department>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    Department dept = new Department();
                    dept.DeptId = Convert.ToInt16(row["DeptId"]);
                    dept.DeptName = Convert.ToString(row["DeptName"]);
                    dept.DeptLocation = Convert.ToString(row["DeptLocation"]);
                    lstDept.Add(dept);
                }
                return lstDept;
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            Department dept = new Department();
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartmentByDeptId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    dept.DeptId = Convert.ToInt16(row["DeptId"]);
                    dept.DeptName = Convert.ToString(row["DeptName"]);
                    dept.DeptLocation = Convert.ToString(row["DeptLocation"]);
                }
            }
            return dept;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            using (SqlConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                //we are passing values to storedprocedure inputparatmennters by using below code
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, department.DeptId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, department.DeptName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, department.DeptLocation);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");

                return true;
            }
        }
    }
}
