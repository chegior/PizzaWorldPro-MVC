using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaWorldPro.MVCClient.Models;
using PizzaWorldPro.Storing;
using PizzaWorldPro.Domain.Models;
using System.Text;
using System.Collections.Generic;

namespace PizzaWorldPro.MVCClient.Controllers
{
  public class OrderController:Controller
  {
    private readonly PizzaWorldProRepository _ctx;
    public OrderController(PizzaWorldProRepository context)
    {
      _ctx = context;
    }
    [HttpGet]
    public IActionResult Get(OrderViewModel model)
    {
      model.Stores = _ctx.GetStores();
      model.Crust = _ctx.GetCrust();
      model.Size = _ctx.GetSize();
      return View("Order",model);
    }
    [HttpPost]
    public IActionResult Post(IFormCollection Orderform,OrderViewModel model)
    {

      var user = new User();
      var order = new Order();
      var store = new Store();

      model.StoreSelected = Orderform["StoreSelection"];
      store = _ctx.GetAStore(model.StoreSelected.ToString());
      model.PizzasSelected = Orderform["PizzaSelection"];
      model.SizeSelected = Orderform["SizeSelection"];
      model.CrustSelected = Orderform["CrustSelection"];
      switch (model.PizzasSelected.ToString())
      {
          case "Hawaiian":order.MakeAPizzaaHawaiian(_ctx.GetACrust(model.CrustSelected.ToString()),_ctx.GetASize(model.SizeSelected.ToString()),_ctx.AssemblePizzaHawaiian());break;
          case "Meat":order.MakeAPizzaMeat(_ctx.GetACrust(model.CrustSelected.ToString()),_ctx.GetASize(model.SizeSelected.ToString()),_ctx.AssemblePizzaMeat());break;
          case "Supreme":order.MakeAPizzaSupreme(_ctx.GetACrust(model.CrustSelected.ToString()),_ctx.GetASize(model.SizeSelected.ToString()),_ctx.AssemblePizzaSupreme());break;
          case "Veggie":order.MakeAPizzaVeggie(_ctx.GetACrust(model.CrustSelected.ToString()),_ctx.GetASize(model.SizeSelected.ToString()),_ctx.AssemblePizzaVeggie());break;
      }

      order.Pizzas.Last().PizzaToppings.ForEach( s => model.Toppings.Add(s.ItemName.ToString()));
      model.PizzaPrice = order.Pizzas.Last().PizzaPrice;


      store.Orders.Add(order);
      _ctx.AddOrder(order);


      return View("OrderPass",model);
    }




  }


}
