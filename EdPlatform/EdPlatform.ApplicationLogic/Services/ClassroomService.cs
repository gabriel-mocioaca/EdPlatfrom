using EdPlatform.ApplicationLogic.Abstractions;
using EdPlatform.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdPlatform.ApplicationLogic.Services
{
  public class ClassroomService
  {
    private readonly IClassroomRepository _classroomRepository;

    public ClassroomService(IClassroomRepository classroomRepository) {
      _classroomRepository = classroomRepository;
    }

    public Classroom GetClassroomByClassroomId(string id)
    {
      var classroom = _classroomRepository.GetClassroomByClassroomId(id);
      return classroom;
    }

    public Classroom AddClassroom(string id, string classroomName, string creatorName)
    {
      var classroom = _classroomRepository.Add(new Classroom()
      {
        ClassroomId = id,
        Name = classroomName,
        CreatorName = creatorName,
      }); 

      return classroom;
    }

    public IEnumerable<Classroom> GetClassrooms(string id)
    {
      var classrooms = _classroomRepository.GetClassrooms(id);
      return classrooms;
    }
  }
}
