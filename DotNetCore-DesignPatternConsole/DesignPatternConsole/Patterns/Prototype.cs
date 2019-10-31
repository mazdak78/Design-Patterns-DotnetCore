using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Prototype
{

    public interface ICustomer
    {
        ICustomer Clone();
    }

    public class CustomerType1 : ICustomer
    {
        public string Name { get; set; }

        public CustomerType1(string _name)
        {
            Name = _name;
        }

        public ICustomer Clone()
        {
            return (ICustomer)this.MemberwiseClone();
        }
    }
}
