using System.Collections.Generic;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.MVCClient.Models
{
  public class PizzaViewModel
  {
    public string PizzaName { get; set; }
    public string Size  { get; set; }
    public string Crust  { get; set; }
  }
}
