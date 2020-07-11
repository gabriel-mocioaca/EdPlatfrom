using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdPlatform.EFDataAccess.Repositories
{
  public class MessageRepository : Repository<Message>, IMessageRepository
  {
    public MessageRepository(EdPlatformDbContext dbContext) : base(dbContext) { }

    public IEnumerable<Message> GetMessagesByClassroomId(string classroomId)
    {
      var result = dbContext.Messages.Where(message => message.ClassroomMessages.Any(classroomMessage => classroomMessage.ClassroomId == classroomId));
      return result;
    }
  }
}
