using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdPlatform.EFDataAccess.Repositories
{
  public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
  {
    public ClassroomRepository(EdPlatformDbContext dbContext) : base(dbContext) { }

    public Classroom GetClassroomByClassroomId(string id)
    {
      var result = dbContext.Classrooms.SingleOrDefault(classroom => classroom.ClassroomId == id);
      return result;
    }

    public IEnumerable<Classroom> GetClassrooms(string participantId)
    {
      var result = dbContext.Classrooms.Where(classroom => classroom.UserClassrooms.Any(userClassroom => userClassroom.UserId == participantId));
      return result;
    }
  }
}
