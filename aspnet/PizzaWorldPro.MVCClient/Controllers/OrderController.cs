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
    [BindProperty]
    public User MyUser { get; set; }
    public OrderController(PizzaWorldProRepository context)
    {
      _ctx = context;
      MyUser = new User();
    }
    [HttpGet]
    public IActionResult Get(OrderViewModel model)
    {
      MyUser.NameUser = model.UserName;
      model.Stores = _ctx.GetStores();
      model.Crust = _ctx.GetCrust();
      model.Size = _ctx.GetSize();
      return View("Order",model);
    }
    [HttpPost]
    public IActionResult Post(IFormCollection Orderform,OrderViewModel model)
    {

      var user = new User();
      user.NameUser = Orderform["UserName"];
      var order = new Order();
      var store = new Store();
      user = _ctx.GetUser(user.NameUser);
      model.StoreSelected = Orderform["StoreSelection"];
      store  = _ctx.GetAStore(Orderform["StoreSelection"].ToString());
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
      user.SelectedStore = store;
      order.OrderPrice = order.Pizzas.Sum(p => p.PizzaPrice);
      user.Orders.Add(order);
      store.Orders.Add(order);
      _ctx.AddOrder(order);


      return View("OrderPass",model);
    }




  }


}
