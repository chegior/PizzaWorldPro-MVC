using PizzaWorldPro.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaWorldPro.Domain.Models{
    public class PizzaSupreme :APizzaModel

    {
        protected override void AddToppings()
        {
            PizzaToppings = new List<Toppings>{};
        }
        protected override void AddName()
        {
            PizzaName = "Supreme Pizza";
        }
        protected override void AddPizzaPrice()
        {
             PizzaPrice = 20.00;
        }
         public override void CalculatePrice(double T)
       {
           PizzaPrice += Crust.ItemPrice + Size.ItemPrice + T;
       }

    }
}
