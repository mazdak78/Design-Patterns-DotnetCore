﻿using DesignPatternConsole.Adapter;
using DesignPatternConsole.COR;
using DesignPatternConsole.Flyweight;
using DesignPatternConsole.Patterns.Builder;
using DesignPatternConsole.Patterns.Command;
using DesignPatternConsole.Patterns.CommandFactory;
using DesignPatternConsole.Patterns.Observer;
using DesignPatternConsole.Patterns.Proxy;
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


            #region Proxy
            Console.WriteLine("Proxy:");
            ProxyCustomer proxy = new ProxyCustomer(new CustomerBalance(1000));
            proxy.DoAccounting();

            proxy = new ProxyCustomer(new CustomerBalance(-10));
            proxy.DoAccounting();

            #endregion

            Console.WriteLine("----------------------");

            #region Decorator
            Console.WriteLine("Decorator:");
            Decorator.PostCreator postCreator = new Decorator.PostCreator();
            postCreator.CreatePost();

            Decorator.PostCreator postCreatorWithBalance = new Decorator.PostCreatorWithBalanceChecker(-10);
            postCreatorWithBalance.CreatePost();

            #endregion

            Console.WriteLine("----------------------");

            #region Observer
            Console.WriteLine("Observer Pattern:");

            EntityNotifier nf = new EntityNotifier();
            CustomerObserverA coa = new CustomerObserverA();
            nf.Subscribe(coa);

            CustomerObserverB cob = new CustomerObserverB();
            nf.Subscribe(cob);

            nf.ScanData();
            
            #endregion

            Console.WriteLine("----------------------");

            #region Chain of responsibility
            Console.WriteLine("Chain of responsibility Pattern:");

            HeadEditor editor = new HeadEditor();
            HeadAccounter accounter = new HeadAccounter();
            HeadManager manager = new HeadManager();
            

            //here is the chain
            editor.SetSuperVisor(accounter);
            accounter.SetSuperVisor(manager);

            CustomerBalanceRequest request = new CustomerBalanceRequest();
            request.Balance = 3000;
            request.CustomerName = "John Doe";

            editor.Handle(request);

            request = new CustomerBalanceRequest();
            request.Balance = 7000;
            request.CustomerName = "Jared";

            editor.Handle(request);

            request = new CustomerBalanceRequest();
            request.Balance = 100;
            request.CustomerName = "Maz";

            editor.Handle(request);

            #endregion

            Console.WriteLine("----------------------");

            #region Prototype
            Console.WriteLine("Prototype Pattern:");

            Prototype.CustomerType1 c = new Prototype.CustomerType1("John");
            Console.WriteLine("First time, Customer Name: {0}", c.Name);

            Prototype.CustomerType1 customerType1 = (Prototype.CustomerType1)c.Clone();
            customerType1.Name = "Jared";
            Console.WriteLine("Cloned Customer, Name: {0}", customerType1.Name);
            Console.WriteLine("Second time, Customer Name: {0}", c.Name);

            #endregion

            Console.WriteLine("----------------------");

            #region Flyweight
            Console.WriteLine("Flyweight Pattern:");

            Flyweight.ShapeFactory shapeFactory = new ShapeFactory();
            IShape shape1 = shapeFactory.GetShapeToDisplay(ShapeType.Circle);
            shape1.DrawShape();
            IShape shape2 = shapeFactory.GetShapeToDisplay(ShapeType.Rectangle);
            shape2.DrawShape();
            IShape shape3 = shapeFactory.GetShapeToDisplay(ShapeType.Circle);
            shape3.DrawShape();
            IShape shape4 = shapeFactory.GetShapeToDisplay(ShapeType.Rectangle);
            shape4.DrawShape();

            Console.WriteLine("Number of created shapes: {0}", shapeFactory.ObjectsCount);
            #endregion

            Console.WriteLine("----------------------");

            #region State
            Console.WriteLine("State Pattern:");

            State.LeadContext leadContext = new State.LeadContext(new State.ConcreteState1());

            leadContext.GetStateName();
            leadContext.GoToPrevState();
            leadContext.GoToNextState();

            leadContext.GetStateName();
            leadContext.GoToNextState();

            leadContext.GetStateName();

            #endregion

            Console.WriteLine("----------------------");

            Console.ReadKey();

        }
    }
}
