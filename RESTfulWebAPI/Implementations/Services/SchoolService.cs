using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.DTOs.Student;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Implementations.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        
        public SchoolService(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GenericResponseModel<SchoolCreateDTO>> CreateSchool(SchoolCreateDTO schoolCreateDTO)
        {
            var response = new GenericResponseModel<SchoolCreateDTO>()
            {
                Data = schoolCreateDTO,
                StatusCode = 400
            };
            try
            {
                if (schoolCreateDTO != null)
                {
                    var school = mapper.Map<School>(schoolCreateDTO);
                    await context.AddAsync(school);

                    int result = await context.SaveChangesAsync();

                    if (result > 0)
                    {
                        response.StatusCode = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> DeleteSchool(int Id)
        {
            var response = new GenericResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var deletedSchool = await context.Schools.FindAsync(Id);
                if (deletedSchool != null)
                {
                    context.Remove(deletedSchool);

                    int result = await context.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Data = true;
                        response.StatusCode = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<GenericResponseModel<SchoolGetDTO>> GetSchoolById(int Id)
        {
            var response = new GenericResponseModel<SchoolGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var school = await context.Schools.FindAsync(Id);
                if (school != null)
                {
                    var mappedSchool = mapper.Map<SchoolGetDTO>(school);

                    response.Data = mappedSchool;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<GenericResponseModel<List<SchoolGetDTO>>> ReadSchools()
        {
            var response = new GenericResponseModel<List<SchoolGetDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var school = await context.Schools.ToListAsync();
                if (school != null)
                {
                    var mappedSchool = mapper.Map<List<SchoolGetDTO>>(school);

                    response.Data = mappedSchool;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateSchool(SchoolUpdateDTO schoolUpdateDTO)
        {
            var response = new GenericResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var school = await context.Schools.FindAsync(schoolUpdateDTO.Id);
                if (school != null)
                {
                    var mappedSchool = mapper.Map(schoolUpdateDTO, school);
                    context.Update(mappedSchool);

                    int result = await context.SaveChangesAsync();
                    if (result > 0)
                    {
                        response.Data = true;
                        response.StatusCode = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 500;
            }
            return response;
        }
    }
}
