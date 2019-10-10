using DesignPatternConsole.Adapter;
using DesignPatternConsole.Patterns.Builder;
using DesignPatternConsole.Patterns.Command;
using DesignPatternConsole.Patterns.CommandFactory;
using DesignPatternConsole.Patterns.Singleton;
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

            #region Template 
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

            #region Singleton
            Console.WriteLine("Singleton Pattern:");
            var configs = SingletonContainer.Instance;
            Console.WriteLine(configs.GetConfig("Config 1"));
            Console.WriteLine(configs.GetConfig("Config 2"));
            #endregion

            Console.WriteLine("----------------------");

            #region Builder
            Console.WriteLine("Builder Pattern:");
            ChefDirector cd = new ChefDirector();

            SteakBuilder sb = new SteakBuilder();
            cd.MixMaterials(sb);

            sb.GetFood().Cook();

            PastaBuilder pb = new PastaBuilder();
            cd.MixMaterials(pb);

            pb.GetFood().Cook();


            #endregion

            Console.WriteLine("----------------------");

            #region Command
            Console.WriteLine("Command Pattern:");
            IInformable informable = new Informable();

            ICommand commandGroup1 = new InformGoup1Command(informable);
            ICommand commandGroup2 = new InformGoup2Command(informable);

            Informer informer = new Informer(commandGroup1, commandGroup2);

            informer.InformGoup1();
            informer.InformGoup2();

            #endregion

            Console.WriteLine("----------------------");

            #region Command-Factory
            Console.WriteLine("Command-Factory:");
            var factory = new CommandFactory();
            var command = factory.GetCommand("Command A");
            command.Execute();

            command = factory.GetCommand("Command B");
            command.Execute();

            #endregion

            Console.WriteLine("----------------------");


            Console.ReadKey();

        }
    }
}
