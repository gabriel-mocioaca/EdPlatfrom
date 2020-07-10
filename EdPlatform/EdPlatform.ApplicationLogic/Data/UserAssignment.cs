using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class UserAssignment
  {
    public string UserId { get; set; }
    public string AssignmentId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Assignment Assignment { get; set; }

    public int UserMark { get; set; }
    public int MaximumMark { get; set; }
    public string Answer { get; set; }
  }
}
