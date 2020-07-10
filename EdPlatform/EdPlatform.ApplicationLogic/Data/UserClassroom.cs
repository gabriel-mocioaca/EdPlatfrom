﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Data
{
  public class UserClassroom
  {
    public string UserId { get; set; }
    public string ClassroomId { get; set; }
    public UserAssignment User { get; set; }
    public Classroom Classroom { get; set; }
  }
}
