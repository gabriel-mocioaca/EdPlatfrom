using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Abstractions
{
  public interface IMessageRepository : IRepository<Message>
  {
    IEnumerable<Message> GetMessagesByClassroomId(string classroomId);
  }
}
