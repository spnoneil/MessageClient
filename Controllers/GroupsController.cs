using Microsoft.AspNetCore.Mvc;
using MessageClient.Models;

namespace MessageClient.Controllers
{
  public class GroupsController : Controller
  {
    public IActionResult Index()
    {
      var allGroups = Group.GetGroups();
      return View(allGroups);
    }
  }
}