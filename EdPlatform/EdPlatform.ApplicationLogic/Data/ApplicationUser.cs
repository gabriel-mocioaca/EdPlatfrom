using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class ApplicationUser
  {
    public string UserId { get; set; }

    public ICollection<UserAssignment> UserAssignments { get; set; }
    public ICollection<UserClassroom> UserClassrooms { get; set; }
  }
}
