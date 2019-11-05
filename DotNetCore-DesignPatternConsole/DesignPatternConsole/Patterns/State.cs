using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.State
{
    public interface ILeadStae
    {
        void Next(LeadContext l);
        void Prev(LeadContext l);
        string String(LeadContext l);
    }

    // Context
    public class LeadContext
    {
        public ILeadStae CurrentLeadState { get; set; }

        public LeadContext(ILeadStae l)
        {
            CurrentLeadState = l;
        }

        public void GoToNextState()
        {
            this.CurrentLeadState.Next(this);
        }

        public void GoToPrevState()
        {
            this.CurrentLeadState.Prev(this);
        }

        public string GetStateName()
        {
            return this.CurrentLeadState.String(this);
        }
    }

    //Concrete State 1
    public class ConcreteState1 : ILeadStae
    {
        public void Next(LeadContext l)
        {
            Console.WriteLine("Check conditions. Going to ConcreteState2.");
            l.CurrentLeadState = new ConcreteState2();
        }

        public void Prev(LeadContext l)
        {
            Console.WriteLine("The Lead is in the root state. There is no prev state.");
        }

        public string String(LeadContext l)
        {
            Console.WriteLine("ConcreteState1");
            return "ConcreteState1";
        }
    }

    //Concrete State 2
    public class ConcreteState2 : ILeadStae
    {
        public void Next(LeadContext l)
        {
            Console.WriteLine("There is no next State.");
        }

        public void Prev(LeadContext l)
        {
            
            Console.WriteLine("Check conditions. Going to ConcreteState1.");
            l.CurrentLeadState = new ConcreteState1();
        }

        public string String(LeadContext l)
        {
            Console.WriteLine("ConcreteState2");
            return "ConcreteState2";
        }
    }

}
