using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class ClassroomStudents
  {
    public string StudentId { get; set; }
    public string ClassroomId { get; set; }
    public Student Student { get; set; }
    public Classroom Classroom { get; set; }
  }
}
