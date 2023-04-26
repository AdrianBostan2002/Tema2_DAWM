using DataLayer.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Core.Dtos
{
    public class GetGradesDto
    {
        public RoleType Role { get; set; }

        [AllowNull]
        public int StudentId { get; set; }
    }
}
