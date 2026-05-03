using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodApi_Entities.Dtos;
using ZomatoFoodApi_Entities.Models;

namespace ZomatoFoodApi_Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FileUploadDto, FileUpload>();
            CreateMap<FileUpload, FileUploadDto>();
            //CreateMap<SourceModelClass, DestinationModelClass>().ReverseMap();
            //ReverseMap() is used to create a two-way mapping between the source and destination classes. It allows you to map in both directions without having to define separate mappings for each direction.
        }

    }
}
