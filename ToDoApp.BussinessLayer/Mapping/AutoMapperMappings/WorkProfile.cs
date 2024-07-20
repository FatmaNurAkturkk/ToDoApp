using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.WorkDtos;
using ToDoApp.EntitiesLayer.Domains;

namespace ToDoApp.BussinessLayer.Mapping.AutoMapperMappings
{
    public class WorkProfile:Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDtos>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDtos, WorkUpdateDto>().ReverseMap();
        }
    }
}
