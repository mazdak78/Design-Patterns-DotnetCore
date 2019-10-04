using DesignPatternConsole.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole
{
    public static class Factory
    {
        public enum CampaignType
        {
            Marx,
            Arendt
        }


        public static ICampaign GetCampaign(CampaignType type)
        {
            switch (type)
            {
                case CampaignType.Marx:
                    return new CampaignType1();
                case CampaignType.Arendt:
                    return new CampaignType2();
                default:
                    throw new NotSupportedException();
            }

        }
    }
}
