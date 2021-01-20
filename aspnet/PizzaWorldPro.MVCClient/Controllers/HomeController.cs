using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.MVCClient.Models;
using PizzaWorldPro.Storing;

namespace PizzaWorldPro.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly PizzaWorldProRepository _ctx;


        public HomeController(PizzaWorldProRepository context)
        {
          _ctx = context;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SaveUser(IFormCollection form)
        {
          string temp = form["UserName"];
          var model = new OrderViewModel();
          var MyUser =new User();
          MyUser.NameUser = form["UserName"];
          MyUser = _ctx.GetUser(MyUser.NameUser.ToString());
          if(MyUser == null)
          {
            var user1 = new User();
            user1.NameUser = temp;
            _ctx.AddUser(user1);
            model.UserName = user1.NameUser.ToString();
            return RedirectToAction("Get","order",model);
          }

          model.UserName = MyUser.NameUser.ToString();
          return RedirectToAction("Get","order",model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
