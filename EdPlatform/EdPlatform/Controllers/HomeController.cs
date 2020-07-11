using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EdPlatform.Models;
using EdPlatform.ApplicationLogic.Data;
using EdPlatform.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;

namespace EdPlatform.Controllers
{
  public class HomeController : Controller
  {
    private readonly ClassroomService _classroomService;
    private readonly UserManager<IdentityUser> _userManager;
    public HomeController(ClassroomService classroomService, UserManager<IdentityUser> userManager)
    {
      _classroomService = classroomService;
      _userManager = userManager;
    }

    public IActionResult Index()
    {
      string userId = _userManager.GetUserId(User).ToString();
      IEnumerable<ClassroomViewModel> viewModel = _classroomService.GetClassrooms(userId).Select(s => new ClassroomViewModel
      {
        ClassroomId = s.ClassroomId,
        ClassroomName = s.Name,
        CreatorName = s.CreatorName,
      }).ToList() ;

      return View(viewModel);
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
