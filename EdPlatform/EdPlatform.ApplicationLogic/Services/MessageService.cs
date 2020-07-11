using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Services
{
  public class MessageService
  {
    private readonly IMessageRepository _messageRepository;
    public MessageService(IMessageRepository messageRepository)
    {
      _messageRepository = messageRepository;
    }

    public IEnumerable<Message> GetMessagesInClassroom(string classroomId)
    {
      if(classroomId == null)
      {
        throw new Exception("Null classroomId");
      }
      var messages = _messageRepository.GetMessagesByClassroomId(classroomId);
      return messages;
    }
  }
}
