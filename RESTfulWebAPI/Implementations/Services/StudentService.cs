using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.Abstractions.UnitOfWork;
using RESTfulWebAPI.DTOs.School;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GenericResponseModel<bool>> ChangeSchool(int studentId, int newSchoolId)
        {
            var response = new GenericResponseModel<bool>();
            try
            {
                var student = await unitOfWork.GetRepository<Student>().GetByIdAsync(studentId);
                var newSchool = await unitOfWork.GetRepository<School>().GetByIdAsync(newSchoolId);

                if (student == null || newSchool == null)
                {
                    response.Data = false;
                    response.StatusCode = 404;
                    return response;
                }

                student.School = newSchool;

                unitOfWork.GetRepository<Student>().Update(student);
                var result = await unitOfWork.SaveChangesAsync();

                if (result > 0)
                {
                    response.Data = true;
                    response.StatusCode = 200;
                }
                else
                {
                    response.Data = false;
                    response.StatusCode = 500;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.StatusCode = 500;
                Console.WriteLine(ex.Message);

            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> ChangeSchool(ChangeSchoolDTO changeSchoolDTO)
        {
            var response = new GenericResponseModel<bool>();
            try
            {
                var student = await unitOfWork.GetRepository<Student>().GetByIdAsync(changeSchoolDTO.StudentId);
                var newSchool = await unitOfWork.GetRepository<School>().GetByIdAsync(changeSchoolDTO.NewSchoolId);

                if (student == null || newSchool == null)
                {
                    response.Data = false;
                    response.StatusCode = 404;
                    return response;
                }

                student.School = newSchool;

                unitOfWork.GetRepository<Student>().Update(student);
                var result = await unitOfWork.SaveChangesAsync();

                if (result > 0)
                {
                    response.Data = true;
                    response.StatusCode = 200;
                }
                else
                {
                    response.Data = false;
                    response.StatusCode = 500;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.StatusCode = 500;
                Console.WriteLine(ex.Message);

            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            var response = new GenericResponseModel<bool>();
            try
            {
                if (studentCreateDTO == null)
                {
                    response.Data = false;
                    response.StatusCode = 404;
                    return response;
                }
                var studentRepository = unitOfWork.GetRepository<Student>();
                var mappedStudent = mapper.Map<Student>(studentCreateDTO);

                await studentRepository.AddAsync(mappedStudent);
                var result = await unitOfWork.SaveChangesAsync();
                if (result > 0)
                {
                    response.Data = true;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.StatusCode = 500;
                Console.WriteLine(ex.Message);

            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> DeleteStudent(int Id)
        {
            var response = new GenericResponseModel<bool>();
            try
            {
                var studentRepository = unitOfWork.GetRepository<Student>();
                var deletedStudent = await studentRepository.GetByIdAsync(Id);
                if (deletedStudent == null)
                {
                    response.Data = false;
                    response.StatusCode = 404;
                }
                else
                {
                    studentRepository.Remove(deletedStudent);
                }
                var result = await unitOfWork.SaveChangesAsync();
                if (result > 1)
                {
                    response.Data = true;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.StatusCode = 500;
                Console.WriteLine(ex.Message);

            }
            return response;
        }

        public async Task<GenericResponseModel<List<StudentGetDTO>>> GetAllStudents()
        {
            var response = new GenericResponseModel<List<StudentGetDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var repository = unitOfWork.GetRepository<Student>();
                var students = await repository.GetAll().Include(m => m.School).ToListAsync();
                var listStudents = mapper.Map<List<StudentGetDTO>>(students);
                if (listStudents.Count == 0)
                {
                    response.Data = null;
                    response.StatusCode = 404;
                }
                response.Data = listStudents;
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.StatusCode = 500;
                Console.WriteLine(ex.Message);

            }
            return response;
        }

        public async Task<GenericResponseModel<StudentGetDTO>> GetStudentById(int Id)
        {
            var response = new GenericResponseModel<StudentGetDTO>();
            try
            {
                var Studentrepository = unitOfWork.GetRepository<Student>();
                var Schoolrepository = unitOfWork.GetRepository<School>();

                var student = await Studentrepository.GetByIdAsync(Id);
                await Schoolrepository.GetByIdAsync(student.Id);
                var mappedStudent = mapper.Map<StudentGetDTO>(student);
                if (mappedStudent == null)
                {
                    response.Data = null;
                    response.StatusCode = 404;
                }
                response.Data = mappedStudent;
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Data = null;
                Console.WriteLine(ex.Message);

            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateStudent(StudentUpdateDTO studentUpdateDTO, int Id)
        {
            var response = new GenericResponseModel<bool>();
            try
            {
                var studentRepository = unitOfWork.GetRepository<Student>();
                if (studentUpdateDTO == null)
                {
                    response.StatusCode = 404;
                    response.Data = false;
                }
                var student = await studentRepository.GetByIdAsync(Id);
                mapper.Map(studentUpdateDTO, student);
                studentRepository.Update(student);
                var result = await unitOfWork.SaveChangesAsync();
                if (result > 0)
                {
                    response.Data = true;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Data = false;
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}
