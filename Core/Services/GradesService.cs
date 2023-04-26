using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradesService
    {
        private readonly UnitOfWork unitOfWork;

        public GradesService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GradeAddDto Add(GradeAddDto payload)
        {
            if (payload == null) return null;

            Student student = unitOfWork.Students.GetById(payload.StudentId);

            if (student == null) return null;

            var newGrade = new Grade
            {
                Id = payload.Id,
                Value = payload.Value,
                Course = payload.course,
                Student = student,
                StudentId = student.Id,
                DateCreated = payload.DateCreated
            };

            unitOfWork.Grades.Insert(newGrade);
            unitOfWork.SaveChanges();

            return payload;
        }

        public IEnumerable<Grade> GetAllGradesOrderedFrom(int studentId)
        {
            var grades = unitOfWork.Grades.GetAllGradesFrom(studentId);

            return grades.OrderBy(x => x.DateCreated);
        }

        public IDictionary<CourseType, List<Grade>> GetAllGradesGroupedByCourse()
        {
            var grades = unitOfWork.Grades.GetAll();

            var gradesGroupedByCourse = grades.GroupBy(grade => grade.Course)
            .ToDictionary(g => g.Key, g => g.ToList());

            return gradesGroupedByCourse;
        }
    }
}
