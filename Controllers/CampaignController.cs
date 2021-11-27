using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Xml;

namespace Assignment.Controllers
{
    public class CampaignController : ApiController
    {
        //[HttpGet]
        public List<Campaigns> GetSortedListOfCampaigns()
        {
            List<Campaigns> campaigns = new List<Campaigns>();

            WebRequest req = WebRequest.Create(@"https://testapi.donatekart.com/api/campaign");
            req.Method = "GET";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                StreamReader rd = new StreamReader(resp.GetResponseStream());
                string strXml = rd.ReadToEnd();
                StringReader reader = new StringReader(strXml);
                DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(strXml);
                //XmlDocument doc = JsonConvert.DeserializeXmlNode(strXml);
                //ds.ReadXml(reader);
                dt.DefaultView.Sort = "totalAmount desc";
                DataTable dtSorted = dt.DefaultView.ToTable();
                for (int i = 0; i < dtSorted.Rows.Count; i++)
                {
                    campaigns.Add(new Campaigns()
                    {
                        Title = dtSorted.Rows[i]["title"].ToString(),
                        TotalAmt = dtSorted.Rows[i]["totalAmount"].ToString(),
                        Backers_Count = dtSorted.Rows[i]["backersCount"].ToString(),
                        EndDate = dtSorted.Rows[i]["endDate"].ToString(),
                    });
                }
            }

            return campaigns;
        }
    }
}
