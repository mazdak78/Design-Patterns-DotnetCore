using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Facade
{
    public interface ICustomer
    {
        void CreateCustomer(string customer_name);
    }

    public class Customer : ICustomer
    {
        public void CreateCustomer(string customer_name)
        {
            Console.WriteLine("Create Customer: " + customer_name);
        }
    }

    public interface ICampaign
    {
        void CreateCampaign(string campaign_name);
    }

    public class Campaign : ICampaign
    {
        public void CreateCampaign(string campaign_name)
        {
            Console.WriteLine("Create Campaign: " + campaign_name);
        }
    }

    public interface IPost
    {
        void CreatePost(string post_title);
    }

    public class Post : IPost
    {
        public void CreatePost(string post_title)
        {
            Console.WriteLine("Create Post: " + post_title);
        }
    }

    public class FacadeClass
    {
        private readonly Customer _customer;
        private readonly Campaign _campaign;
        private readonly Post _post;

        public FacadeClass()
        {
            _customer = new Customer();
            _campaign = new Campaign();
            _post = new Post();
        }

        public void CompleteProcess()
        {
            _customer.CreateCustomer("Microsoft");
            _campaign.CreateCampaign("Microsoft Azure");
            _post.CreatePost("10 tips about Microsoft Azure,");
        }
    }


}
