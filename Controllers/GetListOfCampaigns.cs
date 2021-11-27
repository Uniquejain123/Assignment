﻿using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Controllers
{
    public class GetListOfCampaigns : ApiController
    {
        [HttpGet]
        //[Route("~/api/GetListOfCampaigns/GetSortedListOfCampaigns")]
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
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
            }

            return campaigns;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}