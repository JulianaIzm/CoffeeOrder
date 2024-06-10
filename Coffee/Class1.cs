using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrdering
{
    public interface Coffee
    {
        string GetName();
        double GetPrice();
    }

    public class Americano : Coffee
    {
        public string GetName()
        {
            return "Американо";
        }

        public double GetPrice()
        {
            return 100;
        }
    }

    public class Cappuccino : Coffee
    {
        public string GetName()
        {
            return "Каппучино";
        }

        public double GetPrice()
        {
            return 150;
        }
    }

    public class Latte : Coffee
    {
        public string GetName()
        {
            return "Латте";
        }

        public double GetPrice()
        {
            return 180;
        }
    }

    public class CoffeeOrder
    {
        private List<Coffee> _coffees = new List<Coffee>();

        public void AddCoffee(Coffee coffee)
        {
            _coffees.Add(coffee);
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (var coffee in _coffees)
            {
                totalPrice += coffee.GetPrice();
            }
            return totalPrice;
        }
    }
}
