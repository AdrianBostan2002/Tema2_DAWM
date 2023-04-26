using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class GradeAddDto
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public int Value { get; set; }

        [Required]
        public CourseType course { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}