using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TestProject1.Classes
{
    class Connections
    {

        private List<int> tipid = null;
        private List<string> users = null;
        private List<string> links = null;
        private object[] seznam = null;

        public object[] Seznam
        {
            get { return seznam; }
            set { seznam = value; }
        }

        public Connections(string usr)
        {
            tipid = new List<int>();
            users = new List<string>();
            links = new List<string>();

            Connect(usr);
        }

        public void Connect(string usr)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.bettingexpert.com/api/tips/tips/list/0/0/0/0/"+ usr +"/0");
            string username = "USERNAME";
            string token = "TOKEN";
            request.Headers.Add("X-Username", username);
            request.Headers.Add("X-Api-Token", token);
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

            HttpWebResponse response;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            var stream = response.GetResponseStream();
            string responseBody;
            using (var reader = new StreamReader(stream))
            {
                responseBody = reader.ReadToEnd();
                var test = (JObject)JsonConvert.DeserializeObject(responseBody);
                if (test["result"].ToString() == "[]")
                {
                    return;
                }
                foreach (var newtipid in test["result"])
                {
                    tipid.Add((int)newtipid["intTipId"]);
                    users.Add(newtipid["arrTipAuthor"]["strUsername"].ToString());
                    links.Add(newtipid["strLink"].ToString());
                }
                seznam = new object[3];
                seznam[0] = tipid;
                seznam[1] = users;
                seznam[2] = links;
            }
        }
    }
}
