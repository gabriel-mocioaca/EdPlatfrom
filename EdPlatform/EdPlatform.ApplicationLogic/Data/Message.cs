using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class Message
  {
    public string MessageId { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }

    public ICollection<ClassroomMessage> ClassroomMessages { get; set; }
  }
}
