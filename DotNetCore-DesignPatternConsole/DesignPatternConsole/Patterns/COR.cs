using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.COR
{

    //Request - will be handled by different handlers
    public class CustomerBalanceRequest
    {
        public string CustomerName { get; set; }
        public int Balance { get; set; }
    }

    public interface IBalanceRequest
    {   
        void Handle(CustomerBalanceRequest request);
    }

    // 'Concrete' class
    public abstract class Supervisor : IBalanceRequest
    {
        protected Supervisor _superVisor;
        
        // this is actually setting next block of chain
        public void SetSuperVisor(Supervisor _s)
        {
            _superVisor = _s;
        }

        public abstract void Handle(CustomerBalanceRequest request);

    }

    public class HeadEditor : Supervisor
    {
        public override void Handle(CustomerBalanceRequest request)
        {
            if (request.Balance < 1000)
            {
                Console.WriteLine("{0} approved balance for {2} request. Balance: {1}", this.GetType().Name, request.Balance, request.CustomerName);
            }
            else if (_superVisor != null)
            {
                _superVisor.Handle(request);
            }
        }
    }

    public class HeadAccounter : Supervisor
    {
        public override void Handle(CustomerBalanceRequest request)
        {
            if (request.Balance <= 5000)
            {
                Console.WriteLine("{0} approved balance for {2} request. Balance: {1}", this.GetType().Name, request.Balance, request.CustomerName);
            }
            else if (_superVisor != null)
            {
                _superVisor.Handle(request);
            }
        }
    }

    public class HeadManager : Supervisor
    {
        public override void Handle(CustomerBalanceRequest request)
        {
            if (request.Balance > 5000)
            {
                Console.WriteLine("{0} approved balance for {2} request. Balance: {1}", this.GetType().Name, request.Balance, request.CustomerName);
            }
            else if (_superVisor != null)
            {
                _superVisor.Handle(request);
            }
        }
    }

}
