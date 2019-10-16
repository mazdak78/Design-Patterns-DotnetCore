using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.Proxy
{
    interface ICustomerAccounter
    {
        void DoAccounting();
    }

    // Real Object
    public class Customer : ICustomerAccounter
    {
        public void DoAccounting()
        {
            Console.WriteLine("Accounting Done!");
        }
    }

    // Proxy Object
    public class ProxyCustomer : ICustomerAccounter
    {
        private CustomerBalance customerBalance;
        private ICustomerAccounter realCustomer;

        public ProxyCustomer(CustomerBalance c)
        {
            this.customerBalance = c;
            this.realCustomer = new Customer();
        }

        public void DoAccounting()
        {
            if (customerBalance.Balance <= 0)
                Console.WriteLine("Sorry, the balance is not enough.");
            else
                this.realCustomer.DoAccounting();
        }
    }

    public class CustomerBalance
    {
        public int Balance { get; set; }

        public CustomerBalance(int b)
        {
            this.Balance = b;
        }
    }

}
