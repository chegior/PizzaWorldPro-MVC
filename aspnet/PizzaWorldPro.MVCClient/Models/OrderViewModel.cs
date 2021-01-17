using System.Collections.Generic;

namespace PizzaWorldPro.MVCClient.Models
{
  public class OrderViewModel
  {
    public List<string> Stores  { get; set; }
    public List<string> Pizzas  { get; set; }
    public List<string> Size  { get; set; }
    public List<string> Crust  { get; set; }
    public OrderViewModel(){
      Stores = new List<string> {"The Vaticano Pizzas","The Corner Pizzas","The Negozio Pizzas"};
      Pizzas = new List<string> {"Hawaiian","Meat","Supreme","Veggie"};
      Size = new List<string> {"Picola - Small","Medio - Medium","Familiare -Large"};
      Crust = new List<string> {"Regular","Thin-Flat","Stuffed"};
    }


  }
}
