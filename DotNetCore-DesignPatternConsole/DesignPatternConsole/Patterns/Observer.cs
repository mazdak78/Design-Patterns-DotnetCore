using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.Observer
{
    //interface that receive updates
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    // interface that manage notifying
    public interface ISubject
    {
        void Subscribe(IObserver observer);

        void UnSubscribe(IObserver observer);

        void Notify();
    }

    public class EntityNotifier : ISubject
    {
        public int Status { get; set; } = -1;

        // this can be categorize from database, etc
        private List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnSubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in _observers)
            {
                o.Update(this);
            }
        }

        // some business logic to check/process Status and Notify observers
        public void ScanData()
        {
            Random r = new Random();
            Status = r.Next(0, 200);

            this.Notify();
        }
    }

    public class CustomerObserverA: IObserver
    {
        public void Update(ISubject subject)
        {
            if(((EntityNotifier)subject).Status > 100)
            {
                Console.WriteLine("Our Customer A Notified.");
            }
        }
    }

    public class CustomerObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((EntityNotifier)subject).Status < 101)
            {
                Console.WriteLine("Our Customer B Notified.");
            }
        }
    }

}
