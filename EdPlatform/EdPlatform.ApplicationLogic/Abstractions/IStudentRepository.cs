using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Abstractions
{
  public interface IStudentRepository : IRepository<Student>
  {
    IEnumerable<Student> GetStudentsByClassroomId(string classroomId);
  }
}
