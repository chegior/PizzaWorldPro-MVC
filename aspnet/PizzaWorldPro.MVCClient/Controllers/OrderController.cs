using Microsoft.AspNetCore.Mvc;
using PizzaWorldPro.MVCClient.Models;

namespace PizzaWorldPro.MVCClient.Controllers
{
  public class OrderController:Controller
  {

    public IActionResult Index()
    {
      var model = new OrderViewModel();
      return View("Order",model);
    }

  }


}
