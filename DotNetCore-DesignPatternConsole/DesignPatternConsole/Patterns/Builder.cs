using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.Builder
{
    public class Food
    {
        public string Name { get; set; }
        public int TimeToCook { get; set; }
        public string Materials { get; set; }

        public Food(string name, int timeToCook, string materials)
        {
            Name = name;
            TimeToCook = timeToCook;
            Materials = materials;
        }

        public void Cook()
        {
            Console.WriteLine(String.Format("{0} in {1} minutes, will turn into {2}", Materials, TimeToCook, Name));
        }
    }

    public interface IFoodBuilder
    {
        Food GetFood();
    }

    public class SteakBuilder: IFoodBuilder
    {
       
        public Food GetFood()
        {
            return new Food("Steak", 20, "Meat, Onion, Mushroom");
        }
    }

    public class PastaBuilder : IFoodBuilder
    { 
        public Food GetFood()
        {
            return new Food("Pasta", 30, "Tomato, Pasta, Meat, Onion");
        }
    }

    // Director Class
    public class ChefDirector
    {
        private IFoodBuilder _builder;

        public void MixMaterials(IFoodBuilder builder)
        {
            _builder = builder;
            _builder.GetFood();
        }
    }
}
