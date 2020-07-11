using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdPlatform.ApplicationLogic.Services;
using EdPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdPlatform.Controllers
{
  public class ClassroomController : Controller
  {
    private readonly ClassroomService _classroomService;
    private readonly MessageService _messageService;

    public ClassroomController(ClassroomService classroomService, MessageService messageService)
    {
      _classroomService = classroomService;
      _messageService = messageService;
    }

    [HttpGet]
    public IActionResult CreateClassroom()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ShowClassroom(string id)
    {
      var classroom = _classroomService.GetClassroomByClassroomId(id);

      ClassroomViewModel viewModel = new ClassroomViewModel
      {
        ClassroomId = classroom.ClassroomId,
        ClassroomName = classroom.Name,
        CreatorName = classroom.CreatorName,
        Messages = _messageService.GetMessagesInClassroom(id),
      };

      return View(viewModel);
    }

    [HttpPost]
    public IActionResult CreateClassroom(ClassroomViewModel viewModel)
    {
      string id = viewModel.ClassroomId;
      string classroomName = viewModel.ClassroomName;
      string creatorName = viewModel.CreatorName;

      
      _classroomService.AddClassroom(id, classroomName, creatorName);

      ViewBag.message = "The classroom has been created successfully!";

      return View(viewModel);
    }

  }
}