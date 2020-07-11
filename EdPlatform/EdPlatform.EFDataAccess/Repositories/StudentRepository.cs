using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdPlatform.EFDataAccess.Repositories
{
  public class StudentRepository : Repository<Student>, IStudentRepository
  {
    public StudentRepository(EdPlatformDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Student> GetStudentsByClassroomId(string classroomId)
    {
      var result = dbContext.Students.Where(student => student.ClassroomStudents.Any(classroomStudent => classroomStudent.ClassroomId == classroomId));
      return result;
    }
  }
}
