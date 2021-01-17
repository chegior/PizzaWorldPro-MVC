using System;
using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorldPro.Domain.Models;

namespace PizzaWorldPro.Domain.Abstracts

{
    public class APizzaModel : AEntity
    {
        public string PizzaName{get;set;}
        public Crust Crust {get;set;}
        public Size Size {get;set;}
        public double PizzaPrice { get; set; }
        public List<Toppings> PizzaToppings{get; set;}

        protected APizzaModel()
        { 
            AddName();
            AddPizzaPrice();
            AddToppings();
        }

        public virtual void CalculatePrice(){}
        protected virtual void AddName(){}
        protected virtual void AddPizzaPrice(){}
        protected virtual void AddToppings(){}
        
        
    }
}