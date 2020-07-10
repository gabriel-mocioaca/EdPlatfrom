using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class ClassroomMessage
  {
    public string ClassroomId { get; set; }
    public string MessageId { get; set; }
    public Classroom Classroom { get; set; }
    public Message Message { get; set; }
  }
}
