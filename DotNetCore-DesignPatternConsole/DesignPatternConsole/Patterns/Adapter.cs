using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Adapter
{
    public class TargetFood
    {
        public List<string> GetFoods()
        {
            List<string> foods = new List<string>();
            foods.Add("Steak");
            foods.Add("Ceviche");
            foods.Add("Hamburger");

            return foods;
        }
    }

    class AdapteeDrink
    {
        public string GetDrinks()
        {
            return "Wine,Lemonade,Coca-cola";
        }
    }

    class ChefAdapter : TargetFood
    {
        private readonly AdapteeDrink _adaptee;

        public ChefAdapter(AdapteeDrink adaptee)
        {
            this._adaptee = adaptee;
        }

        public void AdaptFoodsAndDrinks()
        {
            string[] drinks = _adaptee.GetDrinks().Split(',');

            for (int i = 0; i < GetFoods().Count; i++)
            {
                Console.WriteLine(string.Format("Serve {0} with {1}", GetFoods()[i], drinks[i]));
            }


        }
    }
}
