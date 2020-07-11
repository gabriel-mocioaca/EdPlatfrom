using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.EFDataAccess.Repositories
{
  public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
  {
    public AssignmentRepository(EdPlatformDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Assignment> GetAssignmentsByClassroomId(string classroomId)
    {
      throw new NotImplementedException();
    }
  }
}
