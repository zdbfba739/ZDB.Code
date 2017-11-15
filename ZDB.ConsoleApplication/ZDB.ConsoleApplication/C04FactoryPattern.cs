using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDB.ConsoleApplication
{
    public interface IPizza
    {
        string Type { get; }
        void Prepare();
        void Bake();
        void Cut();
        void Box();
    }

    public interface IPizzaStore
    {
        IPizza OrderPizza(string type);
    }

    public abstract class Pizza : IPizza
    {
        public abstract string Type { get; }

        public void Prepare()
        {
            Console.WriteLine($"{Type} is Preparing...");
        }

        public void Bake()
        {
            Console.WriteLine($"{Type} is Baking...");
        }

        public void Cut()
        {
            Console.WriteLine($"{Type} is Cutting...");
        }

        public void Box()
        {
            Console.WriteLine($"{Type} is Boxing...");
        }
    }

    public class CheesePizza : Pizza
    {
        public override string Type => nameof(CheesePizza);
    }

    public class ClamPizza : Pizza
    {
        public override string Type => nameof(ClamPizza);
    }
    public class PepperoniPizza : Pizza
    {
        public override string Type => nameof(PepperoniPizza);
    }

    public class VeggiePizza : Pizza
    {
        public override string Type => nameof(VeggiePizza);
    }

    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            switch (type)
            {
                case nameof(CheesePizza):
                    pizza = new CheesePizza();
                    break;
                case nameof(ClamPizza):
                    pizza = new ClamPizza();
                    break;
                case nameof(PepperoniPizza):
                    pizza = new PepperoniPizza();
                    break;
                case nameof(VeggiePizza):
                    pizza = new VeggiePizza();
                    break;
            }
            return pizza;
        }
    }

    public class PizzaStore : IPizzaStore
    {
        private readonly SimplePizzaFactory _factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public Pizza OrderPizza(string type)
        {
            var pizza = _factory.CreatePizza(type);
            if (pizza != null)
            {
                pizza.Prepare();
                pizza.Bake();
                pizza.Cut();
                pizza.Box();
                Console.WriteLine($"{type} Done!!!");
            }
            else
            {
                Console.WriteLine("We don't have this kind of pizza!!");
            }
            return pizza;
        }
    }
}
