using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.DTOs.School;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Implementations.Services
{
    public class StudentService : IStudentService
    {
        public Task<GenericResponseModel<bool>> ChangeSchool(int studentId, int newSchoolId)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<bool>> ChangeSchool(ChangeSchoolDTO changeSchoolDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<StudentCreateDTO>> CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<bool>> DeleteStudent(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<StudentGetDTO>> GetStudentById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<List<StudentGetDTO>>> ReadStudents()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
