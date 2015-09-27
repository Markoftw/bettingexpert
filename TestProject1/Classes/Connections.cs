using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject1.Classes
{
    class Connections
    {

        //private string shrani = "";
        private List<int> tipid = null;
        private List<string> users = null;
        private List<string> links = null;
        //object = podatkovni tip vseh
        //private = make public getsetter
        private object[] seznam = null;
        
        /*
        * lastnost/property, getsetterji ("funkcija")
        * value = set anything (.Shrani = "loL")
        */
        /*public string Shrani
        {
            get { return shrani; }
            set { shrani = value; }
        }*/

        public object[] Seznam
        {
            get { return seznam; }
            set { seznam = value; }
        }

        //konstruktor
        public Connections(string usr)
        {
            tipid = new List<int>();
            users = new List<string>();
            links = new List<string>();

            //21837
            //201447 isosport

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
            

            /*string postJson =
                "{\"uniqueRequestId\":\"3ca3e7a7-12e1-4907-8b84-00f02e814b1d\"," +
                "\"acceptBetterLine\":\"TRUE\"," +
                "\"stake\":150," +
                "\"winRiskStake\":\"WIN\"," +
                "\"lineId\":104520034," +
                "\"sportId\":29," +
                "\"eventId\":311458946," +
                "\"periodNumber\":0," +
                "\"betType\":\"SPREAD\"," +
                "\"team\":\"TEAM1\"," +
                "\"oddsFormat\":\"AMERICAN\"" +
                "}";

            byte[] byteArray = Encoding.UTF8.GetBytes(postJson);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();*/

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
                //shrani = responseBody;
                var test = (JObject)JsonConvert.DeserializeObject(responseBody);
                if (test["result"].ToString() == "[]")
                {
                    return;
                    //MessageBox.Show("No results found for user " + usr +"!");
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
                //shrani = test["method"].ToString();
                //shrani = links[0].ToString();
            }
        }
    }
}
