using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class Assignment
  {
    public string AssignmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Deadline { get; set; }

    public ICollection<UserAssignment> UserAssignments { get; set; }
  }
}
