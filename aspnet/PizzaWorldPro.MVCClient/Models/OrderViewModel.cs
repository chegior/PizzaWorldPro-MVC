using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.MVCClient.Models
{
  public class OrderViewModel
  {
    [Key]
    public long id { get; set; }
    public List<string> Stores  { get; set; }
    public List<string> Pizzas  { get; set; }
    public List<string> Size  { get; set; }
    public List<string> Crust  { get; set; }
    public string StoreSelected { get; set; }
    public string SizeSelected { get; set; }
    public string CrustSelected { get; set; }
    public string UserName { get; set; }

    public string PizzasSelected { get; set; }
    public double PizzaPrice { get; set; }
    public List<string> Toppings { get; set; }



    public OrderViewModel(){
      Pizzas = new List<string> {"Hawaiian","Meat","Supreme","Veggie"};
      Toppings = new List<string>{};

    }


  }
}
