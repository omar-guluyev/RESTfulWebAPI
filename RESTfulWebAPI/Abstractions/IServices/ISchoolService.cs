using RESTfulWebAPI.DTOs.School;
using RESTfulWebAPI.DTOs.Student;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Abstractions.Services
{
    public interface ISchoolService
    {
        Task<GenericResponseModel<SchoolCreateDTO>> CreateSchool(SchoolCreateDTO schoolCreateDTO);

        Task<GenericResponseModel<List<SchoolGetDTO>>> ReadSchools();
        Task<GenericResponseModel<bool>> UpdateSchool(SchoolUpdateDTO schoolUpdateDTO);
        Task<GenericResponseModel<bool>> DeleteSchool(int Id);
        Task<GenericResponseModel<SchoolGetDTO>> GetSchoolById(int Id);
    }
}
