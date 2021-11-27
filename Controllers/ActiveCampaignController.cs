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
    public class ActiveCampaignController : ApiController
    {
        //[HttpGet]
        public string GetListOfActiveCampaigns()
        {
            WebRequest req = WebRequest.Create(@"https://testapi.donatekart.com/api/campaign");
            req.Method = "GET";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            DataTable dt = new DataTable();
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                StreamReader rd = new StreamReader(resp.GetResponseStream());
                string strXml = rd.ReadToEnd();
                StringReader reader = new StringReader(strXml);
                dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(strXml);
                DateTime dtToday = DateTime.Now;
                DateTime dtMonth = dtToday.AddDays(-30);
                string filter = $"endDate >= '{dtToday}' AND created <= '{dtToday}' AND created > '{dtMonth}'";
                DataRow[] filteredrows = dt.Select(filter);
                dt = filteredrows.CopyToDataTable();
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);

            return json;
        }
    }
}
