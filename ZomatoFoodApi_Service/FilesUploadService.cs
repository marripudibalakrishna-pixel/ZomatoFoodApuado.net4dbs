using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Models;
using ZomatoFoodApi_Entities.StoredProcedureResponseModels;
using ZomatoFoodApi_Repository;

namespace ZomatoFoodApi_Service
{
    
        public class FilesUploadService : IFileUploadService
        {
            public readonly IFileUploadRepository _filesUploadRepository;
            public FilesUploadService(IFileUploadRepository filesUploadRepository)
            {
                _filesUploadRepository = filesUploadRepository;
            }

        public async Task<FileUploadResponse> AddFileUpload(FileUploadDto fileUpload)
        {
            FileUpload obj = new FileUpload();//destinationmodelclass object
                                              //This Code was replaced by above Automapper concept.
            obj.FileName = fileUpload.FileName;
            obj.FilePath = fileUpload.FilePath;
            obj.CreatedDatetTime = fileUpload.CreatedDatetTime;
            obj.Createdby = fileUpload.Createdby;
            obj.ModifiedFilename = fileUpload.ModifiedFilename;
            obj.Id = fileUpload.Id;
            var result = await _filesUploadRepository.AddFileUpload(obj);
            return result;

        }

        public async Task<FileUploadDto> GetFileUploadDetailsById(int Id)
        {
            var result = await _filesUploadRepository.GetFileUploadDetailsById(Id);
            FileUploadDto fileUploadDTO = new FileUploadDto();
            fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            fileUploadDTO.Id = result.Id;
            fileUploadDTO.FileName = result.FileName;
            fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            fileUploadDTO.FilePath = result.FilePath;
            fileUploadDTO.Createdby = result.Createdby;
            fileUploadDTO.CreatedDatetTime = result.CreatedDatetTime;
            return fileUploadDTO;
        }

        public async Task<List<FileUploadDto>> GetFileUploadList()
        {
            var fileUploadList = await _filesUploadRepository.GetFileUploadList();
            List<FileUploadDto> lstFileUploadDTO = new List<FileUploadDto>();
            foreach (var fileUpload in fileUploadList)
            {
                FileUploadDto  fileUploadDTO = new FileUploadDto();
                fileUploadDTO.Id = fileUpload.Id;
                fileUploadDTO.FileName = fileUpload.FileName;
                fileUploadDTO.ModifiedFilename = fileUpload.ModifiedFilename;
                fileUploadDTO.FilePath = fileUpload.FilePath;
                fileUploadDTO.Createdby = fileUpload.Createdby;
                fileUploadDTO.CreatedDatetTime = fileUpload.CreatedDatetTime;
                lstFileUploadDTO.Add(fileUploadDTO);
            }
            return lstFileUploadDTO;
        }
    }
    }

