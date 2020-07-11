using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class Classroom
  {
    public string ClassroomId { get; set; }
    public string Name { get; set; }
    public string CreatorName { get; set; }


    public ICollection<UserClassroom> UserClassrooms { get; set; }
    public ICollection<ClassroomMessage> ClassroomMessages { get; set; }
    public ICollection<ClassroomStudents> ClassroomStudents { get; set; }
  }
}
