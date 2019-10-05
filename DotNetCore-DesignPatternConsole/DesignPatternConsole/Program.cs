﻿using DesignPatternConsole.Adapter;
using DesignPatternConsole.Strategy;
using DesignPatternConsole.Template;
using System;

namespace DesignPatternConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Strategy 
            Console.WriteLine("Strategy Pattern:");
            CampaignType1 ct1 = new CampaignType1();
            ct1.Create("Karl Marx");

            CampaignType2 ct2 = new CampaignType2();
            ct2.Create("Hannah Arendt");
            #endregion
            
            Console.WriteLine("----------------------");

            #region Strategy With Factory        
            Console.WriteLine("Factory + Strategy Pattern:");
            Factory.GetCampaign(Factory.CampaignType.Marx).Create("Capital");
            Factory.GetCampaign(Factory.CampaignType.Arendt).Create("The Origins of Totalitarianism");
            #endregion

            Console.WriteLine("----------------------");

            #region Strategy With Template 
            Console.WriteLine("Template Pattern:");
            StripeCustomer sc = new StripeCustomer();
            sc.CreateCustomer();

            PaypalCustomer pc = new PaypalCustomer();
            pc.CreateCustomer();
            #endregion

            Console.WriteLine("----------------------");

            #region Facade
            Console.WriteLine("Facade Pattern:");
            Facade.FacadeClass fc = new Facade.FacadeClass();
            fc.CompleteProcess();
            #endregion

            Console.WriteLine("----------------------");


            #region Adapter
            Console.WriteLine("Adapter Pattern:");
            AdapteeDrink adaptee = new AdapteeDrink();
            ChefAdapter target = new ChefAdapter(adaptee);
            target.AdaptFoodsAndDrinks();
            #endregion

            Console.WriteLine("----------------------");


            Console.ReadKey();

        }
    }
}
