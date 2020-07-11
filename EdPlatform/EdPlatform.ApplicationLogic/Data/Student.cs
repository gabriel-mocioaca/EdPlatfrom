using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class Student
  {
    public string StudentId { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }

    public ICollection<ClassroomStudents> ClassroomStudents { get; set; }
  }
}
