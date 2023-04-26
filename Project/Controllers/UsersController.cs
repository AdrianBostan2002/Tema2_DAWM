using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService userService { get; set; }

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            userService.Register(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload)
        {
            var jwtToken = userService.Validate(payload);

            return Ok(new { token = jwtToken });
        }

        [HttpGet("/student_get_all_grades")]
        [Authorize(Roles = "Student")]
        public IActionResult GetAllGrades()
        {
            int studentId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == "studentId").Value));   

            var grades = userService.GetAllGradesFromStudent(studentId);
            if (grades != null)
            {
                return Ok(grades);
            }
            return BadRequest("There is no student with such id");
        }

        [HttpGet("/teacher_get_all_grades")]
        [Authorize(Roles = "Teacher")]
        public IActionResult GetAllGradesTeacher()
        {
            var grades = userService.GetAllGradesFromTeacher();
            if (grades != null)
            {
                return Ok(grades);
            }
            return BadRequest();
        }
    }
}