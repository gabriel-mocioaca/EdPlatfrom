using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class Classroom
  {
    public string ClassroomId { get; set; }
    public string Name { get; set; }


    public ICollection<UserClassroom> UserClassrooms { get; set; }
    public ICollection<ClassroomMessage> ClassroomMessages { get; set; }
  }
}
