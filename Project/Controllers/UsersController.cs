using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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

        [HttpGet("/get_all_grades")]
        [Authorize(Roles = "Student, Teacher")]
        public IActionResult GetAllGrades()
        {
            var token = Request.Headers["Authorization"].ToString().Substring(7);

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var role = jwtToken.Claims.First(c => c.Type == "role").Value;
            var studentId = jwtToken.Claims.First(c => c.Type == "studentId").Value;

            if (role == RoleType.Student.ToString()) 
            {
                var grades = userService.GetAllGradesFromStudent(int.Parse(studentId));
                if(grades!=null)
                {
                    return Ok(grades);
                }
                return BadRequest("There is no student with such id");
            }
            else
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
}