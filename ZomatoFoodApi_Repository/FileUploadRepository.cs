using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.StoredProcedureResponseModels;
using ZomatoFoodApi_Entities.Utils;

namespace ZomatoFoodApi_Repository
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public FileUploadRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<FileUploadResponse> AddFileUpload(FileUpload fileUpload)
        {
            FileUploadResponse fileUploadResponse = new FileUploadResponse();
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileName", fileUpload.FileName);
                cmd.Parameters.AddWithValue("@FilePath", fileUpload.FilePath);
                cmd.Parameters.AddWithValue("@ModifiedFilename", fileUpload.ModifiedFilename);
                cmd.Parameters.AddWithValue("@Createdby", fileUpload.Createdby);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    fileUploadResponse.ERROR_CODE = Convert.ToString(dr["ERROR_CODE"]);
                    fileUploadResponse.ERROR_MESSAGE = Convert.ToString(dr["ERROR_MESSAGE"]);
                }
            }
            return fileUploadResponse;
        }
        

        public async Task<FileUpload> GetFileUploadDetailsById(int Id)
        {
            FileUpload fileUpload = new FileUpload();
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetFileUploadDetailsById_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {
                    fileUpload.Id = Convert.ToInt32(dr["Id"]);
                    fileUpload.FileName = Convert.ToString(dr["FileName"]);
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                    fileUpload.FilePath = Convert.ToString(dr["FilePath"]);
                    fileUpload.Createdby = Convert.ToString(dr["Createdby"]);
                    fileUpload.CreatedDatetTime = Convert.ToDateTime(dr["CreatedDateTime"]);


                }
                return fileUpload;
            }

        }

        public async Task<List<FileUpload>> GetFileUploadList()
        {
            List<FileUpload> lstfiles = new List<FileUpload>();//it will store list of file upload details which we are fetching from the database
            //Don't hardcode the connection string below way, instead use the connection factory to get the connection string information from the appsettings.json file or from the environment variables or from the user secrets or from any other secure place where you are storing the connection string information
            // string conectonstring = "Server=DESKTOP-AAO14OC;Database=hotelmanagement;integrated security=yes;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
            using (SqlConnection con = _connectionFactory.HotelmanagementsqlConnectionString())//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetFileUpload_SP, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "FileUpload");
                DataTable dt = new DataTable();
                dt = ds.Tables["FileUpload"];
                foreach (DataRow dr in dt.Rows)
                {//every time we will stroe one record in object of file upload and then we will add that object in the list of file upload details
                    FileUpload fileUpload = new FileUpload();
                    fileUpload.Id = Convert.ToInt32(dr["Id"]);
                    fileUpload.FileName = Convert.ToString(dr["FileName"]);
                    fileUpload.ModifiedFilename = Convert.ToString(dr["ModifiedFilename"]);
                    fileUpload.FilePath = Convert.ToString(dr["FilePath"]);
                    fileUpload.Createdby = Convert.ToString(dr["Createdby"]);
                    fileUpload.CreatedDatetTime = Convert.ToDateTime(dr["CreatedDateTime"]);
                    lstfiles.Add(fileUpload);
                }
            }
            return lstfiles;

        }


    }
}
