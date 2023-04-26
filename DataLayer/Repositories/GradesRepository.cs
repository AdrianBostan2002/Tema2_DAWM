using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GradesRepository : RepositoryBase<Grade>
    {
        public GradesRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Grade> GetAllGradesFrom(int studentId)
        {
            return _dbContext.Grades.Where(x=>x.StudentId==studentId);
        }
    }
}