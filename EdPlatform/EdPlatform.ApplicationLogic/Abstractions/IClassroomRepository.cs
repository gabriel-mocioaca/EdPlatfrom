using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Abstractions
{
  public interface IClassroomRepository : IRepository<Classroom>
  {
    IEnumerable<Classroom> GetClassrooms(string participantId);
    Classroom GetClassroomByClassroomId(string id);
  }
}
