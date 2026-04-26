using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.StoredProcedureResponseModels;

namespace ZomatoFoodApi_Entities.Interfaces
{
    public interface IFileUploadService
    {
        Task<FileUploadResponse> AddFileUpload(FileUploadDto fileUpload);//this is used to add the file information
        Task<List<FileUploadDto>> GetFileUploadList();//this is used fetch ttal files data
        Task<FileUploadDto> GetFileUploadDetailsById(int Id);//this is used to featch files based on id based

    }
}
