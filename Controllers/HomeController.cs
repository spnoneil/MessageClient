using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageClient.Models;

namespace MessageClient.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
        // var testGroup = Group.GetDetails("NAME OF GROUP");
        Group DouglasMurphy = new Group("Douglas Murphy Fan Club of America");
      // Group.Post(DouglasMurphy);
      Group BBBros = new Group("B Bros");
      Group.Put("NAME OF GROUP", BBBros);
      // try
      // {
      //   var outputGroups = Group.GetGroups();
      //   Console.WriteLine(outputGroups[0].GroupName);
      //   for (int i = 0; i < 30; i++) {
      //       Console.WriteLine(outputGroups[i].GroupName);
      //   }
      // }
      // catch (Exception e)
      // {
      //   Console.WriteLine(e.Message);

      // }
      // finally
      // {
      // }
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
