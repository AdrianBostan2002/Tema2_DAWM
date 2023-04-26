using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private StudentService studentService { get; set; }

        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("/add")]
        [Authorize]
        public IActionResult Add(StudentAddDto payload)
        {
            var result = studentService.AddStudent(payload);

            if (result == null)
            {
                return BadRequest("Student cannot be added");
            }

            return Ok(result);
        }


        [HttpGet("/get-all")]
        [Authorize]
        public ActionResult<List<Student>> GetAll()
        {
            var results = studentService.GetAll();

            return Ok(results);
        }

        [HttpGet("/get/{studentId}")]
        [Authorize]
        public ActionResult<Student> GetById(int studentId)
        {
            var result = studentService.GetById(studentId);

            if(result == null)
            {
                return BadRequest("Student not fount");
            }

            return Ok(result);
        }

        [HttpPatch("edit-name")]
        [Authorize]
        public ActionResult<bool> EditById([FromBody] StudentUpdateDto studentUpdateModel)
        {
            var result = studentService.EditName(studentUpdateModel);

            if (!result)
            {
                return BadRequest("Student could not be updated.");
            }

            return result;
        }

        [HttpPost("grades-by-course")]
        [Authorize]
        public ActionResult<GradesByStudent> Get_CourseGrades_ByStudentId([FromBody] StudentGradesRequest request)
        {
            var result = studentService.GetGradesById(request.StudentId, request.CourseType);
            return Ok(result);
        }

        [HttpGet("{classId}/class-students")]
        [Authorize]
        public IActionResult GetClassStudents([FromRoute] int classId)
        {
            var results = studentService.GetClassStudents(classId);

            return Ok(results);
        }

        [HttpGet("grouped-students")]
        [Authorize]
        public IActionResult GetGroupedStudents()
        {
            var results = studentService.GetGroupedStudents();

            return Ok(results);
        }
    }
}
