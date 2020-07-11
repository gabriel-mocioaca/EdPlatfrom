using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Abstractions
{
  public interface IAssignmentRepository : IRepository<Assignment>
  {
    IEnumerable<Assignment> GetAssignmentsByClassroomId(string classroomId);
  }
}
