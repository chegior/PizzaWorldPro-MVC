using System.Collections.Generic;
using System.Linq;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Storing
{
  public class  PizzaWorldProRepository
  {
    private PizzaWorldProContext _ctx;

    public  PizzaWorldProRepository(PizzaWorldProContext context)
    {
      _ctx = context;
    }

    public List<string> GetStores()
    {
      return _ctx.Stores.Select(s => s.Name).ToList();
    }
    public List<string> GetCrust()
    {
      return _ctx.Crusts.Select(s => s.ItemName).ToList();
    }

    public AItemModel GetACrust(string item)
    {
      return _ctx.Crusts.FirstOrDefault(s => s.ItemName == item);
    }

    public List<string> GetSize()
    {
      return _ctx.Sizes.Select(s => s.ItemName).ToList();
    }
     public AItemModel GetASize(string item)
    {
      return _ctx.Sizes.FirstOrDefault(s => s.ItemName == item);
    }

    public List<Toppings> AssemblePizzaHawaiian()
    {
        List<Toppings> DefaultToppings = new List<Toppings>{};
        DefaultToppings.Add(getToppings("Pineapple"));
        DefaultToppings.Add(getToppings("Ham"));
        DefaultToppings.Add(getToppings("Mozarella"));
        DefaultToppings.Add(getToppings("Green Olives"));
        return DefaultToppings;
    }
    public List<Toppings> AssemblePizzaMeat()
    {
        List<Toppings> DefaultToppings = new List<Toppings>{};
        DefaultToppings.Add(getToppings("Tomatoes"));
        DefaultToppings.Add(getToppings("Pepperoni"));
        DefaultToppings.Add(getToppings("Mushrooms"));
        DefaultToppings.Add(getToppings("Onions"));
        return DefaultToppings;
    }

    public List<Toppings> AssemblePizzaSupreme()
    {
        List<Toppings> DefaultToppings = new List<Toppings>{};
        DefaultToppings.Add(getToppings("Bacon"));
        DefaultToppings.Add(getToppings("Green Peppers"));
        DefaultToppings.Add(getToppings("Mozarella"));
        DefaultToppings.Add(getToppings("Onions"));
        return DefaultToppings;
    }

    public List<Toppings> AssemblePizzaVeggie()
    {
        List<Toppings> DefaultToppings = new List<Toppings>{};
        DefaultToppings.Add(getToppings("Basil"));
        DefaultToppings.Add(getToppings("Baby Spinach"));
        DefaultToppings.Add(getToppings("Black Olives"));
        DefaultToppings.Add(getToppings("Cheese-feta"));
        return DefaultToppings;
    }
    public Toppings getToppings(string name)
    {
        return _ctx.Toppings.FirstOrDefault(t => t.ItemName == name);
    }
  }
}
