using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class GetListCampaigns
    {
        public Campaigns CampaignDtls { get; set; }
    }
    public class Campaigns
    {
        public string Title { get; set; }
        public string TotalAmt { get; set; }
        public string Backers_Count { get; set; }
        public string EndDate { get; set; }
    }
}