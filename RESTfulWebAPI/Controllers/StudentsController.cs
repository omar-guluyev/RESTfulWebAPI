using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulWebAPI.Abstractions.Services;
using RESTfulWebAPI.DTOs.School;

namespace RESTfulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateDTO studentCreateDTO)
        {
            var result = await studentService.CreateStudent(studentCreateDTO);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await studentService.GetAllStudents();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await studentService.GetStudentById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentUpdateDTO studentUpdateDTO, int Id)
        {
            var result = await studentService.UpdateStudent(studentUpdateDTO, Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var result = await studentService.DeleteStudent(Id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
