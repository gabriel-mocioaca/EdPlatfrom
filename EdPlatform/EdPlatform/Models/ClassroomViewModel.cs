using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EdPlatform.Models
{
  public class ClassroomViewModel
  {
    public string ClassroomId { get; set; }
    [Required]
    public string ClassroomName { get; set; }
    [Required]
    public string CreatorName { get; set; }

    public IEnumerable<Message> Messages { get; set; }
    public IEnumerable<Assignment> Assignments { get; set; }
    public IEnumerable<ApplicationUser> Students { get; set; }
  }
}
