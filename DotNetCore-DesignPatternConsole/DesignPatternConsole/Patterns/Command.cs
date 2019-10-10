using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
    }

    /* An interface that defines actions that the receiver can perform */
    public interface IInformable
    {
        void InformGoup1();
        void InformGoup2();
    }

    /* The Receiver class */
    public class Informable : IInformable
    {
        public void InformGoup1()
        {
            // based on various factors, we decide, inform Group 1
            Console.WriteLine("Group 1 Informed");
        }

        public void InformGoup2()
        {
            // based on various factors, we decide, inform Group 2
            Console.WriteLine("Group 2 Informed");
        }
    }

    /* The Command informing group 1 - ConcreteCommand #1 */
    public class InformGoup1Command : ICommand
    {
        private IInformable _informable;
        

        public InformGoup1Command(IInformable informable)
        {
            _informable = informable;
        }

        public void Execute()
        {
            _informable.InformGoup1();
        }
    }

    /* The Command informing group 2 - ConcreteCommand #2 */
    public class InformGoup2Command : ICommand
    {
        private IInformable _informable;

        public InformGoup2Command(IInformable informable)
        {
            _informable = informable;
        }

        public void Execute()
        {
            _informable.InformGoup2();
        }
    }
    

    //Invoker class
    public class Informer
    {
        ICommand _group1InformerCommnad;
        ICommand _group2InformerCommnad;

        public Informer(ICommand group1InformerCommnad, ICommand group2InformerCommnad)
        {
            _group1InformerCommnad = group1InformerCommnad;
            _group2InformerCommnad = group2InformerCommnad;
        }

        // inform group 1
        public void InformGoup1()
        {
            this._group1InformerCommnad.Execute();
        }

        // inform group 2
        public void InformGoup2()
        {
            this._group2InformerCommnad.Execute();
        }
    }
}
