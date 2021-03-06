using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorldPro.Domain.Abstracts;
using PizzaWorldPro.Domain.Factories;



namespace PizzaWorldPro.Domain.Models
{
    public class Order : AEntity
    {

        public DateTime OrderTime {get; set;}
        public double OrderPrice { get; set; }

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
        public List<APizzaModel> Pizzas { get; set; }
        public Order()
        {
            Pizzas = new List<APizzaModel>(){};
            OrderTime = DateTime.Now;

        }
        public void MakeAPizzaMeat(AItemModel C, AItemModel S, List<Toppings> T)
        {

            Pizzas.Add(_pizzaFactory.Make<PizzaMeat>());
            Pizzas.Last().Crust = (Crust)C;
            Pizzas.Last().Size = (Size)S;
            Pizzas.Last().PizzaToppings = T;
            var tp = T.Sum( x => x.ItemPrice);
            Pizzas.Last().CalculatePrice(tp);

        }
        public void MakeAPizzaVeggie(AItemModel C, AItemModel S, List<Toppings> T)
        {

            Pizzas.Add(_pizzaFactory.Make<PizzaVeggie>());
            Pizzas.Last().Crust = (Crust)C;
            Pizzas.Last().Size = (Size)S;
            Pizzas.Last().PizzaToppings = T;
            var tp = T.Sum( x => x.ItemPrice);
            Pizzas.Last().CalculatePrice(tp);
        }
        public void MakeAPizzaaHawaiian(AItemModel C, AItemModel S, List<Toppings> T)
        {

            Pizzas.Add(_pizzaFactory.Make<PizzaHawaiian>());
            Pizzas.Last().Crust = (Crust)C;
            Pizzas.Last().Size = (Size)S;
            Pizzas.Last().PizzaToppings = T;
            var tp = T.Sum( x => x.ItemPrice);
            Pizzas.Last().CalculatePrice(tp);
        }
        public void MakeAPizzaSupreme(AItemModel C, AItemModel S, List<Toppings> T)
        {
            Pizzas.Add(_pizzaFactory.Make<PizzaSupreme>());
            Pizzas.Last().Crust = (Crust)C;
            Pizzas.Last().Size = (Size)S;
            Pizzas.Last().PizzaToppings = T;
            var tp = T.Sum( x => x.ItemPrice);
            Pizzas.Last().CalculatePrice(tp);
        }

    }
}
