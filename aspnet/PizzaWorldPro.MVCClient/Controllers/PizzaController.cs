using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWorldPro.MVCClient.Models;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.Storing;
using System.Text;

namespace PizzaWorldPro.MVCClient.Controllers
{

  public class PizzaController:Controller
  {
    [HttpGet]
    public IActionResult index()
    {
      var Pizza = new PizzaViewModel();
      return View("Pizza");
    }

    [HttpPost]
    public IActionResult PizzasOrdered(OrderViewModel selection)
    {
      Console.WriteLine(selection.Crust.ToString());
      if(selection != null)
      {

        var model = new OrderViewModel();
        return View(model);
      }
      else
      return View("OrderFail");

    }
  }
}
