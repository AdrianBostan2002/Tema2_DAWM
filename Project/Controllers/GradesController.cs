using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly GradesService gradesService;

        public GradesController(GradesService gradesService)
        {
            this.gradesService = gradesService;
        }

        [HttpPost]
        public IActionResult AddGrade(GradeAddDto payload)
        {
            var result = gradesService.Add(payload);

            if (result == null)
            {
                return BadRequest("Grade cannot be added");
            }

            return Ok(result);
        }

        [HttpGet("all-grades-from/{studentId}")]
        public IActionResult GetAllGradesFrom(int studentId)
        {
            var result = gradesService.GetAllGradesOrderedFrom(studentId);

            if (result == null)
            {
                return BadRequest("Student doesn't have any grade");
            }

            return Ok(result);
        }

        [HttpGet("all-grades-grouped-by-courses")]
        public IActionResult GetAllGradesFrom()
        {
            var result = gradesService.GetAllGradesGroupedByCourse();

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}