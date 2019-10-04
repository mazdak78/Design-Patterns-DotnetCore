using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Template
{
    public abstract class Customer
    {
        
        protected virtual void CreateCustomerInGateway()
        {
            
        }

        protected virtual void CreateInInternalDatabase()
        {
            Console.WriteLine("Customer created inside internal database.");
        }

        public virtual void CreateCustomer()
        {
            CreateInInternalDatabase();
            CreateCustomerInGateway();
        }
    }

    public class StripeCustomer: Customer
    {
        protected override void CreateInInternalDatabase()
        {
            base.CreateInInternalDatabase();
        }

        protected override void CreateCustomerInGateway()
        {
            Console.WriteLine("Customer created inside Stripe");
        }
    }

    public class PaypalCustomer : Customer
    {
        protected override void CreateInInternalDatabase()
        {
            base.CreateInInternalDatabase();
        }

        protected override void CreateCustomerInGateway()
        {
            Console.WriteLine("Customer created inside Paypal");
        }
    }
}
