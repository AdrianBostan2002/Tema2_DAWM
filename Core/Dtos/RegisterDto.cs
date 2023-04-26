using DataLayer.Entities;

namespace Core.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public RoleType Role { get; set; }

        public int StudentId { get; set; }
    }
}