using AutoMapper;
using RESTfulWebAPI.DTOs.School;
using RESTfulWebAPI.DTOs.Student;
using RESTfulWebAPI.Entities.ApplicationEntities;

namespace RESTfulWebAPI.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentCreateDTO, Student>().ReverseMap();
            CreateMap<Student, StudentGetDTO>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();

            CreateMap<SchoolCreateDTO, School>().ReverseMap();
            CreateMap<School, SchoolGetDTO>().ReverseMap();
            CreateMap<SchoolUpdateDTO, School>().ReverseMap();
        }
    }
}
