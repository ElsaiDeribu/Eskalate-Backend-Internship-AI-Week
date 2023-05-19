using Application.Features.CheckList.DTOs;
using Application.Features.Task.DTOs;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region Task Mappings
            CreateMap<Domain.Task, TaskDto>().ReverseMap();
            CreateMap<Domain.Task, CreateTaskDto>().ReverseMap();
            CreateMap<Domain.Task, UpdateTaskDto>().ReverseMap();
            #endregion Task Mappings



            #region CheckList Mappings
            CreateMap<CheckList, CheckListDto>().ReverseMap();
            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();
            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();
            #endregion CheckList Mappings
        }
    }
}