using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.DTOs.Student;

namespace RESTfulWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService schoolService;

        SchoolsController(ISchoolService schoolService)
        {
            this.schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchool()
        {
            var result =  await schoolService.ReadSchools();
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchool(SchoolCreateDTO schoolCreateDTO)
        {
            var result = await schoolService.CreateSchool(schoolCreateDTO);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchool(SchoolUpdateDTO schoolUpdateDTO)
        {
            var result = await schoolService.UpdateSchool(schoolUpdateDTO);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchool(int Id)
        {
            var result = await schoolService.DeleteSchool(Id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
