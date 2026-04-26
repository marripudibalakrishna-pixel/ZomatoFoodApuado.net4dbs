using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.StoredProcedureResponseModels;

namespace ZomatoFoodApi_Entities.Interfaces
{
    public interface IFileUploadRepository
    {
        Task<FileUploadResponse> AddFileUpload(FileUpload fileUpload);//this is used to add the file information
        Task<List<FileUpload>> GetFileUploadList();//this is used fetch ttal files data
        Task<FileUpload> GetFileUploadDetailsById(int Id);//this is used to featch files based on id based
    }
}

