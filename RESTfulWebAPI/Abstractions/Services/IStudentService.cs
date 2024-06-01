﻿using RESTfulWebAPI.DTOs.School;
using RESTfulWebAPI.DTOs.Student;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Abstractions.Services
{
    public interface IStudentService
    {
        Task<GenericResponseModel<StudentCreateDTO>> CreateStudent(StudentCreateDTO studentCreateDTO);

        Task<GenericResponseModel<List<StudentGetDTO>>> ReadStudents();
        Task<GenericResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO, int Id);
        Task<GenericResponseModel<bool>> DeleteStudent(int Id);
        Task<GenericResponseModel<StudentGetDTO>> GetStudentById(int Id);

        Task<GenericResponseModel<bool>> ChangeSchool(int studentId, int newSchoolId);
        Task<GenericResponseModel<bool>> ChangeSchool(ChangeSchoolDTO changeSchoolDTO);
    }
}
