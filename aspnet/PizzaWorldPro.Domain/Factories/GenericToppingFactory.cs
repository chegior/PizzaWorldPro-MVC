using PizzaWorldPro.Domain.Abstracts;

namespace PizzaWorldPro.Domain.Factories
{
    class GenericToppingFactory
    {
        public T Assemble<T>() where T : AItemModel,new() 
        {
            return new T();
        }
    }
}