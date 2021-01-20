using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWorldPro.Domain.Models;
using PizzaWorldPro.MVCClient.Models;
using PizzaWorldPro.Storing;

namespace PizzaWorldPro.MVCClient.Controllers
{
  public class StoreController:Controller
  {
    private readonly PizzaWorldProRepository _ctx;
    public StoreController(PizzaWorldProRepository context)
    {
      _ctx = context;
    }

     [HttpGet]
    public IActionResult Index()
    {
      var model = new StoreViewModel();
      model.StoreListString = _ctx.GetStores();
      return View("Store",model);
    }

    [HttpPost]
    public IActionResult Post(IFormCollection form )
    {
      var model = new StoreViewModel();
      model.StoreName = form["listbox"];
      var store  = new Store();
      store = _ctx.getOrdersByStore(model.StoreName);
      model.StoreObj = store;
      //  store.EntityId
      return View("Report",model);
    }




  }
}
