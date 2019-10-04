using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Strategy
{
    public interface ICampaign
    {
        void Create(string name);
    }

    public class CampaignType1 : ICampaign
    {
        public void Create(string name)
        {
            // Campaign Creation logic 1
            Console.WriteLine("CampaignType1: " + name);
        }
    }

    public class CampaignType2 : ICampaign
    {
        public void Create(string name)
        {
            // Campaign Creation logic 1
            Console.WriteLine("CampaignType2: " + name);
        }
    }
}
